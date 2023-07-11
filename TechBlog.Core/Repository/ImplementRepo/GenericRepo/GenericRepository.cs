
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Core.DataContext;

namespace TechBlog.Core.Repository.GenericRepo
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly TechBlogContext _context;
        protected DbSet<TEntity> dbSet;

        public GenericRepository(TechBlogContext context = null)
        {
            this._context = context ?? new TechBlogContext();
            dbSet = context.Set<TEntity>();
        }
        /// <summary>
        /// add
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TEntity entity)
        {
            //context.Entry<TEntity>(entity).State = EntityState.Added;
            dbSet.Add(entity);         
        }
        /// <summary>
        /// add range
        /// </summary>
        /// <param name="entity"></param>
        public void AddRange(TEntity entity)
        {

            dbSet.AddRange(entity);
            _context.SaveChanges();
        }
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            _context.SaveChanges();
        }
        /// <summary>
        /// delete by id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            if (entityToDelete != null)
            {
                dbSet.Remove(entityToDelete);
                _context.SaveChanges();
            }
        }
        /// <summary>
        /// find by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Find(int id)
        {
            return dbSet.Find(id);
        }
        /// <summary>
        /// get all
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public TEntity GetEntityById(int id)
        {
            return dbSet.Find(id);
        }



        //public void GetById(int id)
        //{
        //    return dbSet.Find(id);
        //}

        /// <summary>
        /// update
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
         
        }
        /// <summary>
        /// updaterange
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdateRange(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
