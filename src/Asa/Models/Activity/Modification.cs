using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Asa.DbContexts;

namespace Asa.Models.Activity
{
    public class Modification : ActivityModelBase<Modification, Modification.ViewModel>
    {
        [JsonPropertyName("previous")]
        public Line Previous { get; set; }

        public class ViewModel : ViewModelBase
        {
            [JsonPropertyName("previous_id")]
            public string PreviousId { get; set; }
        }

        public class Transformer : TransformerBase
        {
            private readonly AppDbContext _db;

            public Transformer(AppDbContext db) : base(db)
            {
                _db = db;
            }

            public override async Task<Modification> TransformAsync(ViewModel viewModel, Modification model = null)
            {
                model = await base.TransformAsync(viewModel, model);
                model.Previous = await _db.Lines.FindAsync(viewModel.PreviousId);

                return model;
            }
        }
    }
}
