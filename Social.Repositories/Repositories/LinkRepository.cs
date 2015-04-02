using Social.RepositoriesLibrary.Entities;
using Social.RepositoriesLibrary.Entities.Common;
using Social.RepositoriesLibrary.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Repositories
{
    public class LinkRepository : EntityFromToableRepository<Link>
    {
        public Link GetById(int entityIdFrom, int entityIdTo, LinkType type)
        {
            return Query(l => l.EntityIdFrom == entityIdFrom && l.EntityIdTo == entityIdTo && l.Type == type).SingleOrDefault();
        }
        public IQueryable<Link> GetLikes()
        {
            return Query(l => l.Type == LinkType.Like);
        }
        public int GetNbLikes()
        {
            return GetLikes().Count();
        }

        public override void Delete(Link entity)
        {
            entity.Message = null;
            base.Delete(entity);
        }
    }
}
