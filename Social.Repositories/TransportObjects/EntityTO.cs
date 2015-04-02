using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.TransportObjects
{
    public class EntityTO : ITO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NbLike { get; set; }
        public List<string> LikeStrings { get; set; }
        public IEnumerable<MessageTO> Messages { get; set; }

    }
}
