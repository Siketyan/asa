using Asa.DbContexts;
using Asa.Models.Activity;
using Microsoft.AspNetCore.Mvc;

namespace Asa.Controllers.Activity
{
    [Route("activity/modifications")]
    public class
        ModificationsController : RestControllerBase<Modification, Modification.ViewModel, Modification.Transformer>
    {
        public ModificationsController(AppDbContext db, Modification.Transformer transformer) : base(db, transformer)
        {
        }
    }
}
