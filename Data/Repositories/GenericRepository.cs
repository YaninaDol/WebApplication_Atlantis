using DataAccess.Data;
using RepositoriesLibrary.Interfaces;
using RepositoriesLibrary.Models;

namespace DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
       readonly protected Atlantis20DbContext db;
      
        public GenericRepository(Atlantis20DbContext context)
        {
            this.db = context;
           
        }
     

        public void Create(T item) => db.Set<T>().Add(item); 
       

        public void Delete(int id)
        {
             db.Set<T>().Remove(db.Set<T>().Find(id));
        }

        public T Get(int id) 
        {
          

            return db.Set<T>().Find(id);
            
        }

        public IEnumerable<T> GetAll()=>db.Set<T>().ToList();

       
    }
}
