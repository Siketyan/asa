using System;

namespace Asa.Models.Activity
{
    public class Insertion : IActivityModel
    {
        public string Id { get; set; }

        public User Author { get; set; }

        public Line Line { get; set; }

        public Line Front { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
