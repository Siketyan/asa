using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Asa.Models
{
    public class Line : ModelBase<Line>
    {
        [JsonPropertyName("content")]
        public string Content { get; set; }

        public class ViewModel
        {
            [JsonPropertyName("content")]
            public string Content { get; set; }
        }

        public class Transformer : IModel.ITransformer<Line, ViewModel>
        {
            public Task<Line> TransformAsync(ViewModel viewModel, Line model = null)
            {
                return Task.Run(() =>
                {
                    model ??= Create();
                    model.Content = viewModel.Content;

                    return model;
                });
            }
        }
    }
}
