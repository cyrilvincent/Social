using Social.RepositoriesLibrary.Entities;
using Social.RepositoriesLibrary.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Repositories
{
    public class EntityMetadataRepository : DateableRepository<EntityMetadata>
    {
        public EntityMetadata GetByPseudo(string pseudo)
        {
            return Query(e => e.Pseudo == pseudo).FirstOrDefault();
        }
    }
}
