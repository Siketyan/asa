using System;
using System.Threading.Tasks;

namespace Asa.Models
{
    public interface IModel
    {
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public interface ITransformer<T, in TViewModel>
        {
            public Task<T> TransformAsync(TViewModel viewModel, T model);
        }
    }
}
