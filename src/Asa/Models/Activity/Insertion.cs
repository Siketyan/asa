using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Asa.DbContexts;

namespace Asa.Models.Activity
{
    public class Insertion : ActivityModelBase<Insertion, Insertion.ViewModel>
    {
        [JsonPropertyName("front")]
        public Line Front { get; set; }

        public class ViewModel : ViewModelBase
        {
            [JsonPropertyName("front_id")]
            public string FrontId { get; set; }
        }

        public class Transformer : TransformerBase
        {
            private readonly AppDbContext _db;

            public Transformer(AppDbContext db) : base(db)
            {
                _db = db;
            }

            public override async Task<Insertion> TransformAsync(ViewModel viewModel, Insertion model = null)
            {
                model = await base.TransformAsync(viewModel, model);
                model.Front = await _db.Lines.FindAsync(viewModel.FrontId);

                return model;
            }
        }
    }
}
