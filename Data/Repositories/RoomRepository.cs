using DataAccess.Data;
using RepositoriesLibrary.Interfaces;
using RepositoriesLibrary.Models;

namespace DataAccess
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(Atlantis20DbContext context) : base(context)
        {

        }
    }
}
