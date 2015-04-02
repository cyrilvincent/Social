using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NLog;

namespace Social.RepositoriesLibrary.Repositories.Common
{
    public class RepositoryException : Exception
    {
        //private static Logger logger = LogManager.GetCurrentClassLogger();

        public RepositoryException(Exception innerException)
            : this(innerException.Message, innerException)
        {      
        }

        public RepositoryException(string message, Exception innerException) : base(message, innerException)
        {
            //logger.Error("Repository Exception : " + message + " " + innerException.StackTrace);
        }


    }
}
