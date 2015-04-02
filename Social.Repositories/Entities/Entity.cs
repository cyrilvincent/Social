using Social.RepositoriesLibrary.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Entities
{
    public class Entity : IVisibilitable
    {
        public int Id { get; set; }
        public int MetaDataId { get; set; }
        public string Name { get; set; }
        public bool Bannished { get; set; }
        public Visibility Visibility { get; set; }
        public EntityType Type { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Link> FromLinks { get; set; }
        public virtual ICollection<Link> ToLinks { get; set; }
        public virtual ICollection<Message> FromMessages { get; set; }
        public virtual ICollection<Message> ToMessages { get; set; }

        public virtual EntityMetadata Metadata { get; set; }

        public Entity()
        {
            Likes = new List<Like>();
            FromLinks = new List<Link>();
            ToLinks = new List<Link>();
            FromMessages = new List<Message>();
            ToMessages = new List<Message>();
            Type = EntityType.Guest;
            Visibility = Common.Visibility.Private;
        }

        public override string ToString()
        {
            return Name + "(E" + Id + ")";
        }
    }
}
