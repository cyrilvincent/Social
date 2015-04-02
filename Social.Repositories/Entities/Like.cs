using Social.RepositoriesLibrary.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Entities
{
    public class Like : IDateable
    {
        public int Id
        {
            get
            {
                throw new ArgumentException("No Like.Id");
#pragma warning disable
                return 0;
#pragma warning restore
            }
            set { throw new ArgumentException("No Like.Id"); }

        }
        public int EntityId { get; set; }
        public int MessageId { get; set; }
        public DateTime DateTime { get; set; }

        public virtual Entity Entity { get; set; }
        public virtual Message Message { get; set; }

        public Like()
        {
            this.DateTime = DateTime.Now;
        }

        public override string ToString()
        {
            return Entity.ToString() + " Like Message(" + Message.Id + ")";
        }
    }
}
