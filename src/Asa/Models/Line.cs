using System;

namespace Asa.Models
{
    public class Line : IModel
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
