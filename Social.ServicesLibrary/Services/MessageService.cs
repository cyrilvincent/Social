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
    public class MessageService : AbstractService<Message>
    {
        public MessageRepository MRepository
        {
            get { return (MessageRepository)Repository; }
        }

        public override void Delete(Message entity)
        {
            IDbRepository<Like> lr = ServiceFactory.GetRepositoryInstance<Like>();
            lr.Delete(entity.Likes);
            foreach (Message m in entity.Childrens.ToList())
                Delete(m);
            base.Delete(entity);
            MRepository.Save();
        }

        public virtual IEnumerable<MessageTO> GetTOsByEntityIdFromTo(int? fromId, int? toId, int entityId, int nb = MessageRepository.NbMessage, int afterId = int.MaxValue, int beforeId = 0)
        {
            return MRepository.GetTOsByEntityIdFromTo(null, fromId, toId, entityId, nb, afterId: afterId, beforeId: beforeId);
        }

        public virtual MessageTO GetTOById( int id, int entityId, int nbComment = MessageRepository.NbMessage)
        {
            return MRepository.GetTOsByEntityIdFromTo(id, null, null, entityId, 1, nbComment).FirstOrDefault();
        }

        public virtual void Insert(MessageTO to)
        {
            Message m = new Message
            {
                EntityIdFrom = to.FromId,
                EntityIdTo = to.ToId,
                Text = to.Text,
                Type = MessageType.Message,
                Visibility = Visibility.Public,
                Description = to.Description,
                Url = to.Url,
                ImageUrl = to.ImageUrl,
                VideoUrl = to.VideoUrl,
                Title = to.Title,
                ParentId = to.ParentId,
            };
            if (to.ParentId != null) m.Type = MessageType.Comment;

            MRepository.Insert(m);
            MRepository.Save();
        }

        public virtual void Like(int messageId, int entityId)
        {
            Message m = MRepository.GetById(messageId);
            Like l = m.Likes.Where(ml => ml.EntityId == entityId).FirstOrDefault();
            if (l == null)
                m.Likes.Add(new Like { EntityId = entityId });
            else
                m.Likes.Remove(l);
            MRepository.Save();
        }

        public virtual IEnumerable<CommentTO> GetCommentTOsByParentId(int parentId, int entityId, int afterId = int.MaxValue, int beforeId = 0)
        {
            return MRepository.GetCommentTOsByParentId(null, parentId, entityId, afterId: afterId, beforeId: beforeId);
        }

        public virtual CommentTO GetCommentTOById(int id, int entityId)
        {
            return MRepository.GetCommentTOsByParentId(id, null, entityId).FirstOrDefault();
        }
    }
}
