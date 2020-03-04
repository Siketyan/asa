using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Asa.DbContexts;

namespace Asa.Models.Activity
{
    public abstract class ActivityModelBase<T, TViewModel> : ModelBase<T>, IActivityModel
        where T : IActivityModel, new()
        where TViewModel : ActivityModelBase<T, TViewModel>.ViewModelBase
    {
        [JsonPropertyName("author")]
        public User Author { get; set; }

        [JsonPropertyName("line")]
        public Line Line { get; set; }

        public abstract class ViewModelBase
        {
            [JsonPropertyName("author_id")]
            public string AuthorId { get; set; }

            [JsonPropertyName("line_id")]
            public string LineId { get; set; }
        }

        public abstract class TransformerBase : IModel.ITransformer<T, TViewModel>
        {
            private readonly AppDbContext _db;

            protected TransformerBase(AppDbContext db)
            {
                _db = db;
            }

            public virtual async Task<T> TransformAsync(TViewModel viewModel, T model = default)
            {
                model ??= Create();
                model.Author = await _db.Users.FindAsync(viewModel.AuthorId);
                model.Line = await _db.Lines.FindAsync(viewModel.LineId);

                return model;
            }
        }
    }
}
