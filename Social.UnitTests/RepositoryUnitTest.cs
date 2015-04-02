using NUnit.Framework;
using Social.RepositoriesLibrary.Entities;
using Social.RepositoriesLibrary.Entities.Common;
using Social.RepositoriesLibrary.Repositories;
using Social.RepositoriesLibrary.Repositories.EF;
using Social.RepositoriesLibrary.TransportObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.UnitTests
{
    [TestFixture]
    public class RepositoryUnitTest
    {
        [Test]
        [Category("Repository")]
        public void TR00ADOTest()
        {
            SocialDbContext context = new SocialDbContext();
            IDbConnection conn = context.Database.Connection;
            conn.Open();
            Assert.IsTrue(conn.State == ConnectionState.Open);
            conn.Close();
        }

        [Test]
        [Category("Repository")]
        public void TR01AFirstEFTest()
        {
            SocialDbContext context = new SocialDbContext();
            IEnumerable<EntityMetadata> l = context.EntityMetadatas;
            Assert.IsTrue(l.Count() > 0);
        }

        [Test]
        [Category("Repository")]
        public void TR02FirstRepositoryTest()
        {
            SocialDbContext context = new SocialDbContext();
            EntityMetadataRepository emr = new EntityMetadataRepository();
            emr.DbContext = context;
            IEnumerable<EntityMetadata> l = emr.GetAll();
            Assert.IsTrue(l.Count() > 0);
        }

        [Test]
        [Category("Repository")]
        public void TR03LazyTest()
        {
            SocialDbContext context = new SocialDbContext();
            EntityRepository er = new EntityRepository();
            er.DbContext = context;
            Entity e = er.GetLast();
            EntityMetadata em = e.Metadata;
            Assert.AreEqual(e, em.Entities.First());
        }

        [Test]
        [Category("Repository")]
        public void TR04CRUDTest()
        {
            SocialDbContext context = new SocialDbContext();
            EntityMetadataRepository emr = new EntityMetadataRepository();
            emr.DbContext = context;
            EntityMetadata em = new EntityMetadata { Pseudo = "CRUDTest" };
            int nb = emr.Count();
            emr.Insert(em);
            emr.Save();
            Assert.AreEqual(nb + 1, emr.Count());
            em = emr.GetById(em.Id);
            em.City = "Grenoble";
            emr.Save();
            em = emr.GetById(em.Id);
            Assert.AreEqual("Grenoble", em.City);
            emr.Delete(em);
            emr.Save();
            Assert.AreEqual(nb, emr.Count());
        }

        [Test]
        [Category("Repository")]
        public void TR05ComplexCRUDTest()
        {
            SocialDbContext context = new SocialDbContext();
            EntityRepository er = new EntityRepository();
            er.DbContext = context;
            Entity e = new Entity { Name = "CRUDTest" };
            EntityMetadata em = new EntityMetadata { Pseudo = "CRUDTest" };
            e.Metadata = em;
            int nb = er.Count();
            er.Insert(e);
            er.Save();
            Assert.AreEqual(nb + 1, er.Count());
            e = er.GetById(e.Id);
            Assert.AreEqual(Visibility.Private, e.Visibility);
            e.Name += "X";
            e.Metadata.City = "Grenoble";
            e.Visibility = Visibility.Public;
            er.Save();
            e = er.GetById(e.Id);
            Assert.AreEqual("CRUDTestX", e.Name);
            Assert.AreEqual("Grenoble", e.Metadata.City);
            Assert.AreEqual(Visibility.Public, e.Visibility);
            er.Delete(e);
            er.Save();
            Assert.AreEqual(nb, er.Count());
        }

        [Test]
        [Category("Repository")]
        public void TR06LinkTest()
        {
            SocialDbContext context = new SocialDbContext();
            EntityRepository er = new EntityRepository();
            er.DbContext = context;
            Entity e1 = new Entity { Name = "LinkTest1" };
            Entity e2 = new Entity { Name = "LinkTest2" };
            EntityMetadataRepository emr = new EntityMetadataRepository();
            emr.DbContext = context;
            e1.Metadata = emr.GetAll().First();
            e2.Metadata = e1.Metadata;
            er.Insert(e1);
            er.Insert(e2);
            er.Save();
            int nb = e1.ToLinks.Count();
            Link l = new Link { EntityFrom = e1, EntityTo = e2, Type = LinkType.Like, Status = LinkStatus.Confirmed };
            LinkRepository lr = new LinkRepository();
            lr.DbContext = context;
            lr.Insert(l);
            lr.Save();
            e1 = er.GetById(e1.Id);
            e2 = er.GetById(e2.Id);
            Assert.AreEqual(nb + 1, e1.FromLinks.Count());
            Assert.AreEqual(nb + 1, e2.ToLinks.Count());
            e2.ToLinks.Add(new Link { EntityFrom = e1, Type = LinkType.Friend, Status=LinkStatus.Confirmed });
            er.Save();
            e1 = er.GetById(e1.Id);
            Assert.AreEqual(nb + 2, e1.FromLinks.Count());
            l = lr.GetById(e1.Id, e2.Id, LinkType.Friend);
            Assert.IsNotNull(l);
            Assert.AreEqual(LinkStatus.Confirmed, l.Status);
            lr.Delete(lr.GetByEntityIdFrom(e1.Id));
            er.Delete(e1);
            er.Delete(e2);
            er.Save();
        }

        [Test]
        [Category("Repository")]
        public void TR07MessageTest()
        {
            SocialDbContext context = new SocialDbContext();
            EntityRepository er = new EntityRepository();
            er.DbContext = context;
            Entity e1 = new Entity { Name = "MessageTest1" };
            Entity e2 = new Entity { Name = "MessageTest2" };
            EntityMetadataRepository emr = new EntityMetadataRepository();
            emr.DbContext = context;
            e1.Metadata = emr.GetAll().First();
            e2.Metadata = e1.Metadata;
            er.Insert(e1);
            er.Insert(e2);
            er.Save();
            int nb = e1.ToMessages.Count();
            Message m = new Message { EntityFrom = e1, EntityTo = e2, Text = "MessageTest1" };
            MessageRepository mr = new MessageRepository();
            mr.DbContext = context;
            mr.Insert(m);
            mr.Save();
            e1 = er.GetById(e1.Id);
            e2 = er.GetById(e2.Id);
            Assert.AreEqual(nb + 1, e1.FromMessages.Count());
            Assert.AreEqual(nb + 1, e2.ToMessages.Count());
            e2.ToMessages.Add(new Message { EntityFrom = e1, Text = "MessageTest2" });
            er.Save();
            e1 = er.GetById(e1.Id);
            Assert.AreEqual(nb + 2, e1.FromMessages.Count());
            List<Message> l = mr.GetByEntityIdFromAndTo(e1.Id, e2.Id).ToList();
            Assert.AreEqual(2, l.Count());
            mr.Delete(l);
            er.Delete(e1);
            er.Delete(e2);
            er.Save();
        }

        [Test]
        [Category("Repository")]
        public void TR08CommentTest()
        {
            SocialDbContext context = new SocialDbContext();
            MessageRepository mr = new MessageRepository();
            mr.DbContext = context;
            Message m = mr.GetLast();
            Message c = new Message { EntityFrom = m.EntityFrom, EntityTo = m.EntityTo, Text = "CommentTest", Type = MessageType.Comment, Parent = m };
            int nb = m.Childrens.Count();
            mr.Insert(c);
            mr.Save();
            c = new Message { EntityFrom = m.EntityFrom, EntityTo = m.EntityTo, Text = "CommentTest2", Type = MessageType.Comment, ParentId = m.Id };
            mr.Insert(c);
            mr.Save();
            Assert.AreEqual(nb + 2, m.Childrens.Count());
        }

        [Test]
        [Category("Repository")]
        public void TR09LinkMessageTest()
        {
            SocialDbContext context = new SocialDbContext();
            EntityRepository er = new EntityRepository { DbContext = context };
            Entity e1 = new Entity { Name = "LinkTest1" };
            Entity e2 = new Entity { Name = "LinkTest2" };
            EntityMetadataRepository emr = new EntityMetadataRepository();
            emr.DbContext = context;
            e1.Metadata = emr.GetAll().First();
            e2.Metadata = e1.Metadata;
            er.Insert(e1);
            er.Insert(e2);
            Link l = new Link { EntityFrom = e1, EntityTo = e2 };
            l.Message = new Message { EntityFrom = e1, EntityTo = e2, Text = "MessageTest"};
            LinkRepository lr = new LinkRepository { DbContext = context };
            lr.Insert(l);
            lr.Save();           
            l = lr.GetById(e1.Id, e2.Id, LinkType.Friend);
            Assert.IsNotNull(l.Message);
            MessageRepository mr = new MessageRepository { DbContext = context };
            mr.Delete(l.Message);
            lr.Delete(lr.GetByEntityIdFrom(e1.Id));
            er.Delete(e1);
            er.Delete(e2);
            er.Save();
        }

        [Test]
        [Category("Repository")]
        public void TR10LikeTest()
        {
            SocialDbContext context = new SocialDbContext();
            EntityRepository er = new EntityRepository { DbContext = context };
            Entity e = new Entity { Name = "LikeTest" };
            EntityMetadataRepository emr = new EntityMetadataRepository();
            emr.DbContext = context;
            e.Metadata = emr.GetAll().First();
            er.Insert(e);
            MessageRepository mr = new MessageRepository { DbContext = context };
            Message m = mr.GetFirst();
            int nb = m.Likes.Count();
            m.Likes.Add(new Like { Entity = e });
            mr.Save();
            m = mr.GetFirst();
            Assert.AreEqual(nb + 1, m.Likes.Count());
            LikeRepository lr = new LikeRepository { DbContext = context };
            lr.Delete(lr.GetById(e.Id, m.Id));
            er.Delete(e);
            er.Save();
        }

        [Test]
        [Category("Repository")]
        public void TR12EntityTOTest()
        {
            SocialDbContext context = new SocialDbContext();
            EntityRepository er = new EntityRepository { DbContext = context };
            EntityTO to = er.GetTOById(2, true, 3);
            Assert.IsNotNull(to);
            string res = "";
            foreach (string s in to.LikeStrings)
                res += s;
        }

        [Test]
        [Category("Repository")]
        public void TR13MessageTOTest()
        {
            SocialDbContext context = new SocialDbContext();
            MessageRepository mr = new MessageRepository { DbContext = context };
            List<MessageTO> ie = mr.GetTOsByEntityIdFromTo(null, 1, null, 10, 10).ToList();
            Assert.IsTrue(ie.Count > 0);
            ie = mr.GetTOsByEntityIdFromTo(1, null, null, 1, 1, 0, 3).ToList();
            Assert.IsTrue(ie.Count > 0);
        }

        [Test]
        [Category("Repository")]
        public void TR99CleanTest()
        {
            SocialDbContext context = new SocialDbContext();
            EntityRepository er = new EntityRepository { DbContext = context };
            er.Delete(er.GetByNameContains("CRUDTest"));
            EntityMetadataRepository emr = new EntityMetadataRepository { DbContext = context };
            emr.Delete(emr.GetByPseudo("CRUDTest"));
            IEnumerable<Entity> l = er.GetByNameContains("LinkTest");
            LinkRepository lr = new LinkRepository { DbContext = context };
            foreach (Entity e in l.ToList())
            {
                lr.Delete(e.FromLinks);
                lr.Delete(e.ToLinks);
                er.Delete(e);
            }
            l = er.GetByNameContains("MessageTest");
            MessageRepository mr = new MessageRepository { DbContext = context };
            foreach (Entity e in l.ToList())
            {
                mr.Delete(e.FromMessages);
                mr.Delete(e.ToMessages);
                er.Delete(e);
            }
            mr.Delete(mr.GetByText("CommentTest"));
            l = er.GetByNameContains("LikeTest");
            LikeRepository lir = new LikeRepository { DbContext = context };
            foreach (Entity e in l.ToList())
            {
                lir.Delete(e.Likes);
                er.Delete(e);
            }
            er.Save();
        }
            
    }
}
