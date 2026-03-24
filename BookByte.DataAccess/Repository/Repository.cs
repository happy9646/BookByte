using BookByte.DataAccess.Data;
using BookByte.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookByte.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbset;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            dbset = _context.Set<T>();
        }

        // Add a new entity
        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        // Find by primary key
        public T Get(int id)
        {
            return dbset.Find(id);
        }

        // Get all with optional filter, ordering, and eager loading
        public IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null)
        {
            IQueryable<T> query = dbset;

            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp.Trim());
                }
            }

            if (orderBy != null)
                return orderBy(query).ToList();

            return query.ToList();
        }

        // Get single entity matching filter with optional eager loading
        public T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null)
        {
            IQueryable<T> query = dbset;

            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp.Trim());
                }
            }

            return query.FirstOrDefault();
        }

        // Remove by entity reference
        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        // Remove by primary key id
        public void Remove(int id)
        {
            T entity = dbset.Find(id);
            if (entity != null)
                dbset.Remove(entity);
        }

        // Remove multiple entities at once
        public void RemoveRange(IEnumerable<T> entities)
        {
            dbset.RemoveRange(entities);
        }

        // Update existing entity
        public void Update(T entity)
        {
            dbset.Update(entity);
        }
    }
}