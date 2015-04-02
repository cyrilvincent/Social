using Social.RepositoriesLibrary.Entities;
using Social.RepositoriesLibrary.Repositories;
using Social.RepositoriesLibrary.Repositories.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.StatConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Social by Cyril Vincent 2014");
            Console.WriteLine("============================");
            Console.Write("Connection: ");
            
            EntityMetadataRepository emr = new EntityMetadataRepository();
            emr.DbContext = new SocialDbContext(); //new SocialMySqlDbContext(); 
            EntityMetadata em = emr.GetAll().First();
            Console.WriteLine("ok");
            Console.Write("Number of EntityMetaData: ");
            int nb = emr.Count();
            Console.WriteLine(nb);
            Console.Write("Last EntityMetaData: ");
            em = emr.GetLast();
            Console.WriteLine(em.ToString() + " " + em.DateTime.ToShortDateString() + " " + em.DateTime.ToShortTimeString());
            Console.Write("Number of Entity: ");
            EntityRepository er = new EntityRepository();
            er.DbContext = new SocialDbContext();
            nb = er.Count();
            Console.WriteLine(nb);
            Console.Write("Number of User: ");
            nb = er.GetUsers().Count();
            Console.WriteLine(nb);
            Console.Write("Number of Link: ");
            LinkRepository lr = new LinkRepository();
            lr.DbContext = new SocialDbContext();
            nb = lr.Count();
            Console.WriteLine(nb);
            Console.Write("Last Link: ");
            Link l = lr.GetLast();
            Console.WriteLine(l.ToString() + " " + l.DateTime.ToShortDateString() + " " + l.DateTime.ToShortTimeString());
            Entity e = er.GetById(4);
            Console.Write("Number of Message: ");
            MessageRepository mr = new MessageRepository();
            mr.DbContext = new SocialDbContext();
            nb = mr.Count();
            Console.WriteLine(nb);
            Console.Write("Last Message: ");
            Message m = mr.GetLast();
            Console.WriteLine(m.ToString() + " " + m.DateTime.ToShortDateString() + " " + m.DateTime.ToShortTimeString());
            Console.Write("Number of Like: ");
            LikeRepository lir = new LikeRepository();
            lir.DbContext = new SocialDbContext();
            nb = mr.Count() + lr.GetNbLikes();
            Console.WriteLine(nb);
            Console.Write("Last Like: ");
            Like li = lir.GetLast();
            Console.WriteLine(li.ToString() + " " + m.DateTime.ToShortDateString() + " " + m.DateTime.ToShortTimeString());
            Console.WriteLine("Press a key"); 
            Console.ReadKey();


        }
    }
}
