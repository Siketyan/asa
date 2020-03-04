using Asa.DbContexts;
using Asa.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asa.Controllers
{
    [Route("directories")]
    public class DirectoriesController : RestControllerBase<Directory, Directory.ViewModel, Directory.Transformer>
    {
        public DirectoriesController(AppDbContext db, Directory.Transformer transformer) : base(db, transformer)
        {
        }
    }
}
