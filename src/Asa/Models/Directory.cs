using System;

namespace Asa.Models
{
    public class Directory : IModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Directory Parent { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
