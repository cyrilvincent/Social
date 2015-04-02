using Social.RepositoriesLibrary.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Entities
{
    public class Link : IEntityFromToable
    {
        public int Id
        {
            get { 
                throw new ArgumentException("No Link.Id");
#pragma warning disable
                return 0;
#pragma warning restore
            }
            set { throw new ArgumentException("No Link.Id"); }

        }
        public int EntityIdFrom { get; set; }
        public int EntityIdTo { get; set; }
        public LinkType Type { get; set; }
        public DateTime DateTime { get; set; }
        public int? MessageId { get; set; }

        public virtual Entity EntityFrom { get; set; }
        public virtual Entity EntityTo { get; set; }
        public virtual LinkStatus Status { get; set; }
        public virtual Message Message { get; set; }

        public Link()
        {
            Type = LinkType.Friend;
            Status = LinkStatus.Demand;
            this.DateTime = DateTime.Now;
        }
        public override string ToString()
        {
            return EntityFrom.ToString() + "->" + EntityTo.ToString() + " " + Type.ToString() + Status.ToString();
        }
    }
}
