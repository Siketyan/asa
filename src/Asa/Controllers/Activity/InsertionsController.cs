using Asa.DbContexts;
using Asa.Models.Activity;
using Microsoft.AspNetCore.Mvc;

namespace Asa.Controllers.Activity
{
    [Route("activity/insertions")]
    public class InsertionsController : RestControllerBase<Insertion, Insertion.ViewModel, Insertion.Transformer>
    {
        public InsertionsController(AppDbContext db, Insertion.Transformer transformer) : base(db, transformer)
        {
        }
    }
}
