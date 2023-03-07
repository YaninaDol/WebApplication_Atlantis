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
    }
}
