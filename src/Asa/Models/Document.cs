using System;

namespace Asa.Models
{
    public class Document : IModel
    {
        public string Id { get; set; }
        
        public bool IsPinned { get; set; }

        public Line Title { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
