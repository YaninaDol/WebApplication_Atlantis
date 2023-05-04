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

        public bool DeleteCategory( int Id)
        {

            if (db.Rooms.ToList().Where(x => x.Category.Equals(Id)).Count() > 0)
            {
                return false;
            }
            else
            {
                db.Categories.Remove(db.Categories.ToList().Where(x => x.Id.Equals(Id)).FirstOrDefault());
                return true;
            }

          
        }


       

        public List<RoomSide> getRoomSides()=>db.RoomSides.ToList();
       
        bool ICategoryRep.UpdateCategory(int id, string categoryName, string bedTypes)
        {
            if (db.Categories.ToList().Any(x => x.Id == id))

            {

                db.Categories.ToList().Where((x) => x.Id.Equals(id)).FirstOrDefault().Name = categoryName;
                db.Categories.ToList().Where((x) => x.Id.Equals(id)).FirstOrDefault().BedTypes = bedTypes;
                return true;



            }
            return false;
        }
    }
}
