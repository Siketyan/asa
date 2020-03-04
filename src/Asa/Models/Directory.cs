using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Asa.DbContexts;

namespace Asa.Models
{
    public class Directory : ModelBase<Directory>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("parent")]
        public Directory Parent { get; set; }

        public class ViewModel
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("parent_id")]
            public string ParentId { get; set; }
        }

        public class Transformer : IModel.ITransformer<Directory, ViewModel>
        {
            private readonly AppDbContext _db;

            public Transformer(AppDbContext db)
            {
                _db = db;
            }

            public async Task<Directory> TransformAsync(ViewModel viewModel, Directory model = null)
            {
                model ??= Create();
                model.Name = viewModel.Name;
                model.Parent = await _db.Directories.FindAsync(viewModel.ParentId);

                return model;
            }
        }
    }
}
