using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookByte.DataAccess.Repository.IRepository
{
    public class IUnitOfWork
    { 
        ICategoryRepository Category { get; } 
        ICoverTypeRepository CoverType { get; }
        void Save();
    }
}
