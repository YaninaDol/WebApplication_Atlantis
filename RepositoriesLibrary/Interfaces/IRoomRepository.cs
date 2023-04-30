using RepositoriesLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoriesLibrary.Models;

namespace RepositoriesLibrary
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        IEnumerable<Room> getAllList();
        string getSide(int id);

        bool Update(int IdUpdate, Room item);

        IEnumerable<Room> Availability(DateTime Start, DateTime End,  int Adults, int Children);

        bool booking (int roomNumber,string Userid, string FirstName, int totaldays, string LastName, DateTime Start, DateTime End,string phoneNumber,string notice);

    }
}
