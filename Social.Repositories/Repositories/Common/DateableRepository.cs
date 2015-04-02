using Social.RepositoriesLibrary.Entities.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Repositories.Common
{
    public abstract class DateableRepository<T> : AbstractRepository<T>, IDbRepository<T> where T : class, IDateable
    {
        public override T GetLast()
        {
            string s = GetAll().OrderByDescending(e => e.DateTime).ToString();
            return GetAll().OrderByDescending(e => e.DateTime).First();
        }
        public override IQueryable<T> GetLasts(Expression<Func<T, bool>> predicate, int nb)
        {
            return Query(predicate).OrderByDescending(e => e.DateTime).Take(nb);
        }
    }
}
