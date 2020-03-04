using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Asa.DbContexts;

namespace Asa.Models
{
    public class Document : ModelBase<Document>
    {
        [JsonPropertyName("title")]
        public Line Title { get; set; }

        [JsonPropertyName("is_pinned")]
        public bool IsPinned { get; set; }

        public class ViewModel
        {
            [JsonPropertyName("title_id")]
            public string TitleId { get; set; }

            [JsonPropertyName("is_pinned")]
            public bool IsPinned { get; set; }
        }

        public class Transformer : IModel.ITransformer<Document, ViewModel>
        {
            private readonly AppDbContext _db;

            public Transformer(AppDbContext db)
            {
                _db = db;
            }

            public async Task<Document> TransformAsync(ViewModel viewModel, Document model = null)
            {
                model ??= Create();
                model.Title = await _db.Lines.FindAsync(viewModel.TitleId);
                model.IsPinned = viewModel.IsPinned;

                return model;
            }
        }
    }
}
