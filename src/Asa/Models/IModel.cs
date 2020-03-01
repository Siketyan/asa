using System;

namespace Asa.Models
{
    public interface IModel
    {
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
