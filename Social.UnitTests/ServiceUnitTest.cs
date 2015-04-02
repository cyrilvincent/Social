using NUnit.Framework;
using Social.RepositoriesLibrary.Entities;
using Social.RepositoriesLibrary.Entities.Common;
using Social.RepositoriesLibrary.Repositories;
using Social.RepositoriesLibrary.Repositories.EF;
using Social.RepositoriesLibrary.TransportObjects;
using Social.ServicesLibrary.Factories;
using Social.ServicesLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.UnitTests
{
    [TestFixture]
    public class ServiceUnitTest
    {
        [Test]
        [Category("Service")]
        public void TS01DebugUnityTest()
        {
            string s = UnityHelper.Debug();
            Assert.IsTrue(s.Contains("Entity"));
        }

        [Test]
        [Category("Service")]
        public void TS02EntityUnityTest()
        {
            Entity e = (Entity)UnityHelper.EntityResolve<Entity>();
            Assert.NotNull(e);
        }

        [Test]
        [Category("Service")]
        public void TS03RepositoryUnityTest()
        {
            EntityRepository er = (EntityRepository)UnityHelper.RepositoryResolve<Entity>();
            Entity e = er.GetFirst();
            Assert.IsNotNull(e);
        }

        [Test]
        [Category("Service")]
        public void TS04EntityFactoryTest()
        {
            EntityMetadata em = ServiceFactory.GetEntityInstance<EntityMetadata>();
            Assert.IsNotNull(em);
            Entity e = ServiceFactory.GetEntity();
            Assert.IsNotNull(e);
            Assert.IsNotNull(e.Metadata);
            Link l = ServiceFactory.GetLink(e, e, LinkType.Friend);
            Assert.IsNotNull(l);
            Message m = ServiceFactory.GetMessage(e, e);
            Assert.IsNotNull(m);
            Like li = ServiceFactory.GetLike(e, m);
            Assert.IsNotNull(li);
        }

        [Test]
        [Category("Service")]
        public void TS05RepositoryFactoryTest()
        {
            EntityRepository er = (EntityRepository)ServiceFactory.GetRepositoryInstance<Entity>();
            Entity e = er.GetFirst();
            Assert.IsNotNull(e);
        }

        [Test]
        [Category("Service")]
        public void TS06ServiceUnityTest()
        {
            EntityService es = (EntityService)UnityHelper.ServiceResolve<Entity>();
            Entity e = es.GetById(-1);
            Assert.IsNotNull(e);
        }

        [Test]
        [Category("Service")]
        public void TS07ServiceFactoryTest()
        {
            EntityService es = (EntityService)ServiceFactory.GetServiceInstance<Entity>();
            Entity e = es.GetById(-1);
            Assert.IsNotNull(e);
        }

        [Test]
        [Category("Service")]
        public void TS09MessageTOTest()
        {
            MessageService ms = (MessageService)UnityHelper.ServiceResolve<Message>();
            MessageTO to = ms.GetTOById(1, -1);
            Assert.IsNotNull(to);
        }

        [Test]
        [Category("Service")]
        public void TS08LogonTest()
        {
            EntityMetadataService es = (EntityMetadataService)ServiceFactory.GetServiceInstance<EntityMetadata>();
            Entity e = es.Logon("cyril", "");
            Assert.IsNotNull(e);
            e = es.Logon("pmlokijuhyt", "");
            Assert.IsNull(e);
        }

        [Test]
        [Category("Service")]
        public void TS99CleanTest()
        {
            
        }
            
    }
}
