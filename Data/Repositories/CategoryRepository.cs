using DataAccess.Data;
using RepositoriesLibrary;
using RepositoriesLibrary.Models;

namespace DataAccess
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRep
    {
        public CategoryRepository(Atlantis20DbContext context) : base(context)

        {

        }

        public bool DeleteCategory(int Id)
        {

            //if (db.Rooms.ToList().Where(x => x.Category.Equals(Id)).Count() > 0)
            //{
            //    return false;
            //}
            //else
            //{
            //    db.Categories.Remove(db.Categories.ToList().Where(x => x.Id.Equals(Id)).FirstOrDefault());
            //    return true;
            //}

            return false;
        }
    }
}
