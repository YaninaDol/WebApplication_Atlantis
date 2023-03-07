using RepositoriesLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoriesLibrary.Models;

namespace RepositoriesLibrary
{
    public interface ICategoryRep:IGenericRepository<Category>
    {
        bool DeleteCategory(int Id);

    }
}
