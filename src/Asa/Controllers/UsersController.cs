using Asa.DbContexts;
using Asa.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asa.Controllers
{
    [Route("users")]
    public class UsersController : RestControllerBase<User, User.ViewModel, User.Transformer>
    {
        public UsersController(AppDbContext db, User.Transformer transformer) : base(db, transformer)
        {
        }
    }
}
