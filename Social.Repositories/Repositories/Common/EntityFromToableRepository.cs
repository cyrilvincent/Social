using Social.RepositoriesLibrary.Entities.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Repositories.Common
{
    public abstract class EntityFromToableRepository<T> : DateableRepository<T>, IDbRepository<T> where T : class, IEntityFromToable
    {

        public IQueryable<T> GetByEntityIdFrom(int entityIdFrom)
        {
            return Query(l => l.EntityIdFrom == entityIdFrom);
        }

        public IQueryable<T> GetByEntityIdFromAndTo(int entityIdFrom, int entityIdTo)
        {
            return Query(l => l.EntityIdFrom == entityIdFrom && l.EntityIdTo == entityIdTo);
        }
    }
}
