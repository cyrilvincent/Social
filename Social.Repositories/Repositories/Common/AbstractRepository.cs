using Social.RepositoriesLibrary.Entities.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Repositories.Common
{
    /// <summary>
    /// Repository crud
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractRepository<T> : IUnitOfWork, IDbRepository<T> where T : class, IDbEntity
    {
        //private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instance du DbContext
        /// </summary>
        public DbContext DbContext { get; set; }
        public static bool DebugMode { get; set; }

        /// <inheritdoc />
        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> result = null;
            try
            {
                result = DbContext.Set<T>();
                if (DebugMode)
                {
                    // Log
                }
            }
            catch(Exception ex)
            {
                throw new RepositoryException(ex);
            }

            return result;
        }

        /// <inheritdoc />
        public virtual T GetById(int id)
        {
            //logger.Debug(ListAll().Where(e => e.Id == id).ToString());
            try {
                return DbContext.Set<T>().Where(e => e.Id == id).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw new RepositoryException(id.ToString(), ex);
            }

        }

        /// <inheritdoc />
        public virtual IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
            // logger TODO
            IQueryable<T> result = null;
            try
            {
                result = DbContext.Set<T>().Where(predicate);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
            return result;
        }

        /// <inheritdoc />
        public virtual IOrderedQueryable<T> Query(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> sort)
        {
            //logger.Debug(Query(predicate).OrderBy(sort).ToString());
            IOrderedQueryable<T> result = null;
            try
            {
                result = DbContext.Set<T>().Where(predicate).OrderBy(sort);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
            return result;
        }

        /// <inheritdoc />
        public virtual IQueryable<T> Query(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> sort, int nbEntity, int page)
        {
            // TODO logger.Debug(Query(predicate).OrderBy(sort).ToString());
            IQueryable<T> result = null;
            try
            {
                result = DbContext.Set<T>().Where(predicate).OrderBy(sort).Skip(page * nbEntity).Take(nbEntity);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
            return result;
        }

        public virtual int Count()
        {
            // TODO logger.Debug(Query(predicate).OrderBy(sort).ToString());
            int result = 0;
            try
            {
                result = DbContext.Set<T>().Count();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
            return result;
        }
        public int Count(Expression<Func<T, bool>> predicate)
        {
            // TODO logger.Debug(Query(predicate).OrderBy(sort).ToString());
            int result = 0;
            try
            {
                result = DbContext.Set<T>().Where(predicate).Count();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
            return result;
        }


        /// <inheritdoc />
        public virtual void Insert(T entity)
        {
            try
            {
                DbContext.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        /// <inheritdoc />
        public virtual void Delete(T entity)
        {
            try
            {
                DbContext.Entry<T>(entity).State = EntityState.Deleted;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (T e in entities.ToList())
                Delete(e);
        }

        public virtual void Update(T entity)
        {
            try
            {
                DbContext.Entry<T>(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        /// <inheritdoc />
        public virtual void Save()
        {
            try
            {
                //DateTime d = DateTime.Now;
                //foreach (DbEntityEntry<IDateable> entry in DbContext.ChangeTracker.Entries<IDateable>())
                //{
                //    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                //    {
                //        entry.Entity.DateTime = d;
                //    }
                //}
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public virtual T GetLast()
        {
            //logger.Debug(ListAll().Where(e => e.Id == id).ToString());
            try
            {
                return DbContext.Set<T>().OrderByDescending(e => e.Id).First();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }
        public virtual IQueryable<T> GetLasts(Expression<Func<T, bool>> predicate, int nb)
        {
            //logger.Debug(ListAll().Where(e => e.Id == id).ToString());
            try
            {
                return DbContext.Set<T>().Where(predicate).OrderByDescending(e => e.Id).Take(nb);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }
        public virtual T GetFirst()
        {
            return DbContext.Set<T>().FirstOrDefault();
        }
        
    }
}
