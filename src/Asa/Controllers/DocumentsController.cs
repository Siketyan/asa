using Asa.DbContexts;
using Asa.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asa.Controllers
{
    [Route("documents")]
    public class DocumentsController : RestControllerBase<Document, Document.ViewModel, Document.Transformer>
    {
        public DocumentsController(AppDbContext db, Document.Transformer transformer) : base(db, transformer)
        {
        }
    }
}
