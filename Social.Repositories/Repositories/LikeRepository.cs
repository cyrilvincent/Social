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
    public class LikeRepository : DateableRepository<Like>
    {
        public Like GetById(int entityId, int messageId)
        {
            return Query(l => l.EntityId == entityId && l.MessageId == messageId).SingleOrDefault();
        }
    }
}
