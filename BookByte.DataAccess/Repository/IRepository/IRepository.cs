using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookByte.DataAccess.Repository.IRepository
{
    // A Generic Repository is a reusable repository that works with any entity type.
    // It uses generics<T> to avoid duplicating CRUD logic for each entity.
    public interface IRepository<T> where T : class
    {
        // Add a new entity to the database
        void Add(T entity);

        // Update an existing entity in the database
        void Update(T entity);

        // Remove a specific entity from the database
        void Remove(T entity);

        // Remove an entity by its primary key id
        void Remove(int id);

        // Remove multiple entities at once
        void RemoveRange(IEnumerable<T> entities);

        // Find and return a single entity by its primary key id
        T Get(int id);                               // ✅ Fixed: was get (lowercase)

        // Get all entities with optional filter, ordering, and eager loading
        // includeProperties example: "Category,CoverType"
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null          // e.g. "Category,CoverType"
        );

        // Get the first entity matching the filter, or null if not found
        // includeProperties example: "Category,CoverType"
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null          // ✅ Fixed: was "null" (string literal)
        );
    }
}