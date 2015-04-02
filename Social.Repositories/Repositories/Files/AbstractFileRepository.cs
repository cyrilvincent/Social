using Social.RepositoriesLibrary.Entities.Common;
using Social.RepositoriesLibrary.Entities.Crawler;
using Social.RepositoriesLibrary.Repositories.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Repositories.Files
{
    public abstract class AbstractFileRepository<T> : IRepository<T> where T: IEntity
    {
        public TextWriter Writer {get;set;}
        public TextReader Reader { get; set; }

        public string Path {get;set;}

        public string Prefix { get; set; }

        public string Suffix { get; set; }

        public void Save()
        {
            Writer.Close();
        }

        public abstract IQueryable<T> GetAll();

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IOrderedQueryable<T> Query(System.Linq.Expressions.Expression<Func<T, bool>> predicate, System.Linq.Expressions.Expression<Func<T, object>> sort)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query(System.Linq.Expressions.Expression<Func<T, bool>> predicate, System.Linq.Expressions.Expression<Func<T, object>> sort, int nbEntity, int page)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T GetLast()
        {
            throw new NotImplementedException();
        }

        public T GetFirst()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetLasts(System.Linq.Expressions.Expression<Func<T, bool>> predicate, int nb)
        {
            throw new NotImplementedException();
        }

        public abstract void Insert(T entity);

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
