using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesLibrary.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        public ICategoryRep CategoryRep { get; }
      
        public IRoomRepository RoomRepository { get; }
       public int Commit();
    }
}
