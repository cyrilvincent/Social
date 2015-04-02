using Social.RepositoriesLibrary.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Entities.Crawler
{
    public class AHref
    {
        public string HRef { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            return string.Format("<a href={0}>{1}</a>",HRef,Content);
        }
    }
}
