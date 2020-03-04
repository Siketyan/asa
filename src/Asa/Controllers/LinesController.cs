using Asa.DbContexts;
using Asa.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asa.Controllers
{
    [Route("lines")]
    public class LinesController : RestControllerBase<Line, Line.ViewModel, Line.Transformer>
    {
        public LinesController(AppDbContext db, Line.Transformer transformer) : base(db, transformer)
        {
        }
    }
}
