using Social.RepositoriesLibrary.Entities;
using Social.RepositoriesLibrary.Repositories;
using Social.RepositoriesLibrary.Repositories.Common;
using Social.ServicesLibrary.Factories;
using Social.ServicesLibrary.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.ServicesLibrary.Services
{
    public class EntityMetadataService : AbstractService<EntityMetadata>
    {
        public EntityMetadataRepository EMRepository
        {
            get { return (EntityMetadataRepository)Repository; }
        }

        public Entity Logon(string pseudo, string pwd)
        {
            Entity e = null;
            EntityMetadata em = EMRepository.GetByPseudo(pseudo.ToUpper());
            if (em != null)
                e = em.Entities.Where(p => !p.Bannished).FirstOrDefault();
            return e;
        }

    }
}
