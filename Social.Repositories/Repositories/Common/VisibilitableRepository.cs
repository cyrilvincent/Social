using Social.RepositoriesLibrary.Entities.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Repositories.Common
{
    public abstract class VisibilitableRepository<T> : AbstractRepository<T>, IDbRepository<T> where T : class, IVisibilitable
    {

    }
}
