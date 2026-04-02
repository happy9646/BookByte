using BookByte.DataAccess.Data;
using BookByte.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookByte.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {  
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
                _context = context; 
            Category = new CategoryRepository(_context);
            CoverType = new CoverTypeRepository(_context);
        }
        public ICategoryRepository Category { private set; get; }

        public ICoverTypeRepository CoverType { private set; get; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
