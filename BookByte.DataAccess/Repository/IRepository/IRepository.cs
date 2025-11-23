using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookByte.DataAccess.Repository.IRepository
{

    //A Generic Repository is a reusable repository that works with any entity type.
    //It uses generics() to avoid duplicating CRUD logic for each entity.
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);

        // when we want to remove an entity by its id 
        void Remove(int id);

        // when we want to remove multiple entities at once
        void RemoveRange(IEnumerable<T> entities);  

        // here this code for find 
        T get(int id);

        // here this code is for display 

        IEnumerable<T> GetAll(
            Expression<Func<T,bool>> filter=null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy=null,
            string includeProperties= "null"  // Category, CoverType
            );
        // here this code is for only one item

         T GetOrDefault(
          Expression<Func<T, bool>> filter = null,
          string includeProperties = "null"

        );

    }
}
