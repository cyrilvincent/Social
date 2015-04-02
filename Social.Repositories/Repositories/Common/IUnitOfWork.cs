using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Repositories.Common
{
    /// <summary>
    /// Interface Unit Of Work
    /// </summary>
    public interface IUnitOfWork
    {
        void Save();
    }
}
