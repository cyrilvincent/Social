using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Social.RepositoriesLibrary.Entities.Common;
using System.Data.Entity;

namespace Social.RepositoriesLibrary.Repositories.Common
{
    /// <summary>
    /// Contrat imposant les méthodes de base
    /// </summary>
    /// <typeparam name="T">Objet de type IEntity (Id obligatoire)</typeparam>
    public interface IDbRepository<T> : IRepository<T>, IUnitOfWork where T : IDbEntity
    {
        DbContext DbContext { get; set; }
        IQueryable<T> Query(Expression<Func<T, bool>> predicate);
        IOrderedQueryable<T> Query(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> sort);
        IQueryable<T> Query(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> sort, int nbEntity, int page);
        int Count(Expression<Func<T, bool>> predicate);
        T GetLast();
        IQueryable<T> GetLasts(Expression<Func<T, bool>> predicate, int nb);
        void Delete(IEnumerable<T> entities);

    }
}
