using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.TransportObjects
{
    public class MessageTO : CommentTO
    {
        public List<CommentTO> Comments { get; set; }
        public int NbComment { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string Title { get; set; }
    
    }
}
