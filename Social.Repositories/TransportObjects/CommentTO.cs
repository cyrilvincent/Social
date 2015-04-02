using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.TransportObjects
{
    public class CommentTO : ITO
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Text { get; set; }
        public int NbLike { get; set; }
        public List<string> LikeStrings { get; set; }
        public bool Liked { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public int? ParentId { get; set; }

    }
}
