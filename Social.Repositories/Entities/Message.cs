using Social.RepositoriesLibrary.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Entities
{
    public class Message : IVisibilitable, IEntityFromToable
    {
        public int Id { get; set; }
        public int EntityIdFrom { get; set; }
        public int EntityIdTo { get; set; }
        public DateTime DateTime { get; set; }
        public string Tags { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public string LongText { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Link> Links { get; set; }
        public virtual ICollection<Message> Childrens { get; set; }

        public virtual Entity EntityFrom { get; set; }
        public virtual Entity EntityTo { get; set; }
        public virtual Message Parent { get; set; }
        public virtual MessageType Type { get; set; }
        public virtual Visibility Visibility { get; set; }

        public Message()
        {
            Likes = new List<Like>();
            Links = new List<Link>();
            Childrens = new List<Message>();
            Type = MessageType.Message;
            Visibility = Common.Visibility.Private;
            this.DateTime = DateTime.Now;
        }

        public override string ToString()
        {
            return EntityFrom.ToString() + "->" + EntityTo.ToString() + " " + Text;
        }
    }
}
