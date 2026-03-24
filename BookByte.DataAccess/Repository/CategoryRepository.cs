using BookByte.DataAccess.Data;
using BookByte.DataAccess.Repository.IRepository;
using BookByte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookByte.DataAccess.Repository
{
    public class CategoryRepository:Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) 
        : base(context)
        {
            _context = context;
        }
    }
}
