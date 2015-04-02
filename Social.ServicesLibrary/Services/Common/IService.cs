using Social.RepositoriesLibrary.Entities.Common;
using Social.RepositoriesLibrary.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.ServicesLibrary.Services.Common
{
    public interface IService<T> where T:IDbEntity
    {
        IDbRepository<T> Repository { get; set; }
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
