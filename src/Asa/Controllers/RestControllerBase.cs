using System.Collections.Generic;
using System.Threading.Tasks;
using Asa.DbContexts;
using Asa.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asa.Controllers
{
    [ApiController]
    public abstract class RestControllerBase<T, TViewModel, TTransformer>
        where T : class, IModel
        where TTransformer : IModel.ITransformer<T, TViewModel>
    {
        private readonly AppDbContext _db;
        private readonly TTransformer _transformer;

        protected RestControllerBase(AppDbContext db, TTransformer transformer)
        {
            _db = db;
            _transformer = transformer;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<T> List()
        {
            return _db.Set<T>();
        }

        [HttpGet]
        [Route("{id}")]
        public async ValueTask<T> LookupAsync([FromRoute] string id)
        {
            return await _db.FindAsync<T>(id);
        }

        [HttpPost]
        [Route("")]
        public async Task<T> CreateAsync([FromBody] TViewModel viewModel)
        {
            var entity = await _transformer.TransformAsync(viewModel, default);
            var entry = await _db.AddAsync(entity);
            await _db.SaveChangesAsync();

            return entry.Entity;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<T> EditAsync([FromRoute] string id, [FromBody] TViewModel viewModel)
        {
            var entity = await _transformer.TransformAsync(viewModel, await LookupAsync(id));
            await _db.SaveChangesAsync();

            return entity;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<T> Delete([FromRoute] string id)
        {
            var entity = await LookupAsync(id);
            var entry = _db.Remove(entity);
            await _db.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
