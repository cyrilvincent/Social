using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Entities.Common
{
    public interface IDbEntity : IEntity
    {
        int Id { get; set; }
    }
}
