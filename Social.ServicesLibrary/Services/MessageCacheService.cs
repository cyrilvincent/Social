using Social.RepositoriesLibrary.Entities;
using Social.RepositoriesLibrary.Repositories;
using Social.RepositoriesLibrary.Repositories.Common;
using Social.RepositoriesLibrary.TransportObjects;
using Social.ServicesLibrary.Factories;
using Social.ServicesLibrary.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.ServicesLibrary.Services
{
    /*public class MessageCacheService : MessageService
    {
        private static Dictionary<int, MessageTO> dico = null;
        private static Dictionary<Tuple<int?, int?>, bool> tuple = null;
        public static long MaxSize { get; set; }
        public static long Size { get; set; }


        public Dictionary<int, MessageTO> Cache
        {
            get
            {
                if (dico == null)
                    Reset();
                return dico;
            }
        }

        public MessageCacheService()
        {
            MaxSize = (long)1E11;
        }

        public void Reset()
        {
            dico = new Dictionary<int, MessageTO>();
            tuple = new Dictionary<Tuple<int?, int?>, bool>();
            IEnumerable<MessageTO> ie = MRepository.GetTOsByEntityIdFromTo(null, null, int.MaxValue, int.MaxValue, true);
            AddToCache(ie);
        }

        public void AddToCache(MessageTO to)
        {
            lock (new Object())
            {
                Size += MessageTOSize(to);
                CheckSize();
                dico[to.Id] = to;
            }
        }

        public void AddToCache(IEnumerable<MessageTO> tos)
        {
            foreach (MessageTO to in tos)
            {
                AddToCache(to);
            }
        }

        public int MessageTOSize(MessageTO to)
        {
            return to.Text.Length * 2 + 64 + 64 + 64 + 32 + to.LikeStrings.Sum(s => s.Length) * 2 + 32 + 64 + 32 + 32 + to.Preview.Length * 2 + 64 + 1;
        }

        public void RemoveFromCache(MessageTO to)
        {
            lock (new Object())
            {
                Size -= MessageTOSize(to);
                dico.Remove(to.Id);
            }
        }

        private void CheckSize()
        {
            if (Size > MaxSize)
            {
                MessageTO to = dico.Values.OrderBy(t => t.Id).First();
                RemoveFromCache(to);
                CheckSize();
            }
        }

        public IOrderedEnumerable<MessageTO> ValuesFromCache()
        {
            return dico.Values.OrderByDescending(t => t.Id);
        }

        public double Ratio
        {
            get { return (double)Size / MaxSize; }
        }

        public override void Insert(MessageTO to)
        {
            base.Insert(to);
            AddToCache(to);
        }
    }*/
}
