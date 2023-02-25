using RepositoriesLibrary;
using RepositoriesLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoriesLibrary.Models;
using DataAccess.Data;

namespace DataAccess.UnitofWork
{
    public class  UnitOfWork : IUnitOfWork
    {
        private readonly Atlantis20DbContext _context;
     
        public UnitOfWork(Atlantis20DbContext context)
        {
            _context = context;
            CategoryRep = new CategoryRepository(_context);
  
            RoomRepository=new RoomRepository(_context);

        }
    


        public ICategoryRep CategoryRep { get;  }

        public IRoomRepository RoomRepository { get; }

        public int Commit()=>_context.SaveChanges();    

        public void Dispose()=>_context?.Dispose(); 
    }
}
