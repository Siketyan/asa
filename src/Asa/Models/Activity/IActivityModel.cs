namespace Asa.Models.Activity
{
    public interface IActivityModel : IModel
    {
        public User Author { get; set; }

        public Line Line { get; set; }
    }
}
