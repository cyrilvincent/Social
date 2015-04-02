using Social.RepositoriesLibrary.Entities.Common;
using Social.RepositoriesLibrary.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.ServicesLibrary.Services.Common
{
    public abstract class AbstractService<T> : IService<T> where T:IDbEntity
    {
        public IDbRepository<T> Repository { get; set; }

        public virtual T GetById(int id)
        {
            return Repository.GetById(id);
        }

        public virtual void Insert(T entity)
        {
            Repository.Insert(entity);  
        }

        public virtual void Update(T entity)
        {
            Repository.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            Repository.Delete(entity);
        }

        public virtual void Save() {
            Repository.Save();
        }
    }
}
