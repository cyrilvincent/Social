using Social.RepositoriesLibrary.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Entities
{
    public class EntityMetadata : IDbEntity, IDateable
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string Mail { get; set; }
        public string Pwd { get; set; }
        public DateTime DateTime { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Internet { get; set; }
        public string Ip { get; set; }
        public virtual ICollection<Entity> Entities { get; set; }

        public EntityMetadata()
        {
            Entities = new List<Entity>();
            this.DateTime = DateTime.Now;
        }

        public override string ToString()
        {
            return Pseudo + ShortName + " (EM" + Id + ")";
        }
    }
}
