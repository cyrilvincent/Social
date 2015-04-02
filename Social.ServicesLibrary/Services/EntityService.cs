using Social.RepositoriesLibrary.Entities;
using Social.RepositoriesLibrary.Entities.Common;
using Social.RepositoriesLibrary.Repositories;
using Social.RepositoriesLibrary.Repositories.Common;
using Social.RepositoriesLibrary.TransportObjects;
using Social.ServicesLibrary.Factories;
using Social.ServicesLibrary.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.ServicesLibrary.Services
{
    public class EntityService : AbstractService<Entity>
    {
        public const int AnonymousId = -1;
        public EntityRepository ERepository
        {
            get { return (EntityRepository)Repository; }
        }

        public override void Delete(Entity entity)
        {
            Entity anonymous = ERepository.GetById(AnonymousId);
            IDbRepository<Link> lr = ServiceFactory.GetRepositoryInstance<Link>();
            lr.Delete(entity.FromLinks);
            lr.Delete(entity.ToLinks);
            IDbRepository<Like> lir = ServiceFactory.GetRepositoryInstance<Like>();
            lir.Delete(entity.Likes);
            foreach (Message m in entity.FromMessages.ToList())
                m.EntityFrom = anonymous;
            foreach (Message m in entity.ToMessages.ToList())
                m.EntityTo = anonymous;
            ERepository.Delete(entity);
            ERepository.Save();
        }

    }
}
