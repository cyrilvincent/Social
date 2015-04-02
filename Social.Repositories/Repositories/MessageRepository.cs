using Social.RepositoriesLibrary.Entities;
using Social.RepositoriesLibrary.Entities.Common;
using Social.RepositoriesLibrary.Repositories.Common;
using Social.RepositoriesLibrary.TransportObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace Social.RepositoriesLibrary.Repositories
{
    public class MessageRepository : EntityFromToableRepository<Message>
    {
        public const int NbMessage = 20;

        public IEnumerable<Message> GetChildMessagesContains(Message m, string s)
        {
            return m.Childrens.Where(c => c.Text.ToUpper().Contains(s.ToUpper()));
        }

        public IQueryable<Message> GetByText(string text)
        {
            return Query(m => m.Text.ToUpper().Contains(text.ToUpper()));
        }

        public IQueryable<Message> GetMessagesByEntityId(int entityId)
        {
            return Query(m => m.EntityIdFrom == entityId && m.EntityIdTo == entityId && (m.Type == MessageType.Message || m.Type == MessageType.LinkMessage));
        }
        public IQueryable<Message> GetLastMessagesByEntityId(int entityId)
        {
            return GetMessagesByEntityId(entityId).Take(NbMessage);
        }
        public IQueryable<Message> GetComments(int messageId)
        {
            return Query(m => m.Type == MessageType.Comment && m.ParentId == messageId);
        }

        public override void Delete(Message entity)
        {
            entity.Links.Clear();
            base.Delete(entity);
        }

        public IEnumerable<MessageTO> GetTOsByEntityIdFromTo(int? messageId, int? fromId = null, int? toId = null, int likeEntityId = -1, int nb = NbMessage, int nbComment = 5, int nbLikeStrings = 5, int afterId = int.MaxValue, int beforeId = 0)
        {
            IQueryable<Message> q = DbContext.Set<Message>();
            q = q.Include("EntityFrom").Include("EntityTo").Include("Childrens").Include("Likes").Include("Likes.Entity");
            q = q.Where(m => (messageId == null ? true : m.Id == messageId) && (fromId == null ? true : m.EntityIdFrom == fromId) && (toId == null ? true : m.EntityIdTo == toId) && m.ParentId == null && m.Type == MessageType.Message && m.Id < afterId && m.Id > beforeId).OrderByDescending(m => m.Id).Take(nb);
            IEnumerable<MessageTO> tos;
            if (nbComment > 0)
            {
                tos = q.Select(m => new MessageTO
                {
                    DateTime = m.DateTime,
                    Id = m.Id,
                    Text = m.Text,
                    From = m.EntityFrom.Name,
                    To = m.EntityTo.Name,
                    FromId = m.EntityIdFrom,
                    ToId = m.EntityIdTo,
                    Description = m.Description,
                    Url = m.Url,
                    ImageUrl = m.ImageUrl,
                    VideoUrl = m.VideoUrl,
                    Title = m.Title,
                    NbLike = m.Likes.Count(),
                    Liked = m.Likes.Any(l => l.EntityId == likeEntityId),
                    LikeStrings = m.Likes.OrderByDescending(l => l.DateTime).Take(nbLikeStrings).Select(l => l.Entity.Name).ToList() ,
                    NbComment = m.Childrens.Count,
                    Comments = m.Childrens.OrderByDescending(c => c.Id).Take(nbComment).Select(c => new CommentTO
                    {
                        DateTime = c.DateTime,
                        Id = c.Id,
                        Text = c.Text,
                        ParentId = c.ParentId,
                        NbLike = c.Likes.Count(),
                        LikeStrings = c.Likes.OrderByDescending(l => l.DateTime).Take(nbLikeStrings).Select(l => l.Entity.Name).ToList(),
                    }).ToList()
                });
            }
            else
            {
                tos = q.Select(m => new MessageTO
                {
                    DateTime = m.DateTime,
                    Id = m.Id,
                    Text = m.Text,
                    From = m.EntityFrom.Name,
                    To = m.EntityTo.Name,
                    FromId = m.EntityIdFrom,
                    ToId = m.EntityIdTo,
                    Description = m.Description,
                    Url = m.Url,
                    ImageUrl = m.ImageUrl,
                    VideoUrl = m.VideoUrl,
                    Title = m.Title,
                    NbLike = m.Likes.Count(),
                    LikeStrings = m.Likes.Select(l => l.Entity.Name).ToList(),
                    NbComment = m.Childrens.Count,
                    Liked = m.Likes.Any(l => l.EntityId == likeEntityId),

                });
            }
            return tos;
        }

        public IEnumerable<CommentTO> GetCommentTOsByParentId(int? messageId, int? parentId = null, int likeEntityId = -1, int nb = NbMessage, int nbLikeStrings = 5, int afterId = int.MaxValue, int beforeId = 0)
        {
            IQueryable<Message> q = DbContext.Set<Message>();
            q = q.Include("EntityFrom").Include("EntityTo").Include("Likes").Include("Likes.Entity");
            q = q.Where(m => (messageId == null ? true : m.Id == messageId) && (parentId == null ? true : m.ParentId == parentId) && m.Type == MessageType.Comment && m.Id < afterId && m.Id > beforeId).OrderByDescending(m => m.Id).Take(nb);
            IEnumerable<MessageTO> tos = q.Select(m => new MessageTO
            {
                DateTime = m.DateTime,
                Id = m.Id,
                Text = m.Text,
                From = m.EntityFrom.Name,
                To = m.EntityTo.Name,
                FromId = m.EntityIdFrom,
                ToId = m.EntityIdTo,
                NbLike = m.Likes.Count(),
                LikeStrings = m.Likes.Select(l => l.Entity.Name).ToList(),
                NbComment = m.Childrens.Count,
                Liked = m.Likes.Any(l => l.EntityId == likeEntityId),
                ParentId = m.ParentId,
            });
            return tos;
        }
    }
}
