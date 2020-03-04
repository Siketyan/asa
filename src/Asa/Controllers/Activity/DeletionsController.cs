using Asa.DbContexts;
using Asa.Models.Activity;
using Microsoft.AspNetCore.Mvc;

namespace Asa.Controllers.Activity
{
    [Route("activity/deletions")]
    public class DeletionsController : RestControllerBase<Deletion, Deletion.ViewModel, Deletion.Transformer>
    {
        public DeletionsController(AppDbContext db, Deletion.Transformer transformer) : base(db, transformer)
        {
        }
    }
}
