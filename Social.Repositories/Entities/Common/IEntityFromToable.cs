using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Entities.Common
{
    public interface IEntityFromToable : IDateable
    {
        int EntityIdFrom { get; set; }
        int EntityIdTo { get; set; }
    }
}
