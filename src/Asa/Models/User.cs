using System;

namespace Asa.Models
{
    public class User : IModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
