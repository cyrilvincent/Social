using Social.RepositoriesLibrary.Entities;
using Social.RepositoriesLibrary.Entities.Common;
using Social.RepositoriesLibrary.Repositories.Common;
using Social.RepositoriesLibrary.TransportObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Repositories
{
    public class EntityRepository : VisibilitableRepository<Entity>
    {
        public IQueryable<Entity> GetUsers()
        {
            IQueryable<Entity> q = Query(e => e.Type == EntityType.User || e.Type == EntityType.Root || e.Type == EntityType.Admin);
            return q;
        }

        public IQueryable<Entity> GetByName(string name)
        {
            return Query(e => e.Name == name);
        }

        public IQueryable<Entity> GetByNameContains(string name)
        {
            return Query(e => e.Name.ToUpper().Contains(name.ToUpper()));
        }

        public EntityTO GetTOById(int id, bool withLike, int nbLikeStrings = 0 )
        {
            IQueryable<Entity> q = DbContext.Set<Entity>();
            if (withLike)
                q = q.Include("ToLinks").Include("ToLinks.EntityFrom");
            q = q.Where(e => e.Id == id);
            IQueryable<EntityTO> tos;
            if(withLike)
                tos = q.Select(e => new EntityTO {
                    Id = e.Id,
                    Name = e.Name,                             
                    NbLike = e.ToLinks.Where(l => l.Type == LinkType.Like).Count(),
                    LikeStrings = e.ToLinks.Where(l => l.Type == LinkType.Like).OrderByDescending(l => l.DateTime).Take(nbLikeStrings).Select(l => l.EntityFrom.Name).ToList()
                });
            else
                tos = q.Select(e => new EntityTO {Id = e.Id, Name = e.Name });
            return tos.FirstOrDefault();
        }
    }
}
