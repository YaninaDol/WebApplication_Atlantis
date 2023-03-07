using DataAccess.Data;
using RepositoriesLibrary;
using RepositoriesLibrary.Models;

namespace DataAccess
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(Atlantis20DbContext context) : base(context)
        {
           
        }


        public IEnumerable<Room> getAllList()
        {
            return db.Rooms.ToList();

        }

        public string getSide(int id)
        {
           return  db.RoomSides.ToList().Where(x => x.Id == id).FirstOrDefault().Name;
        }
    }
}
