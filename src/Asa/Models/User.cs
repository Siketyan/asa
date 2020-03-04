using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Asa.Models
{
    public class User : ModelBase<User>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        public class ViewModel
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }
        }

        public class Transformer : IModel.ITransformer<User, ViewModel>
        {
            public Task<User> TransformAsync(ViewModel viewModel, User model = null)
            {
                return Task.Run(() =>
                {
                    model ??= Create();
                    model.Name = viewModel.Name;

                    return model;
                });
            }
        }
    }
}
