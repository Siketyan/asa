using Asa.DbContexts;

namespace Asa.Models.Activity
{
    public class Deletion : ActivityModelBase<Deletion, Deletion.ViewModel>
    {
        public class ViewModel : ViewModelBase
        {
        }

        public class Transformer : TransformerBase
        {
            public Transformer(AppDbContext db) : base(db)
            {
            }
        }
    }
}
