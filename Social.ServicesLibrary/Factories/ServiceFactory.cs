using Social.RepositoriesLibrary.Entities;
using Social.RepositoriesLibrary.Entities.Common;
using Social.RepositoriesLibrary.Repositories.Common;
using Social.RepositoriesLibrary.TransportObjects;
using Social.ServicesLibrary.Services;
using Social.ServicesLibrary.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.ServicesLibrary.Factories
{
    public static class ServiceFactory
    {
        public static T GetEntityInstance<T>() where T : IDbEntity
        {
            return (T)UnityHelper.EntityResolve<T>();
        }

        public static Entity GetEntity()
        {
            Entity e = GetEntityInstance<Entity>();
            e.Metadata = GetEntityInstance<EntityMetadata>();
            return e;
        }

        public static Link GetLink(Entity from, Entity to, LinkType type)
        {
            Link l = GetEntityInstance<Link>();
            l.EntityFrom = from;
            l.EntityTo = to;
            l.Type = type;
            return l;
        }

        public static Message GetMessage(Entity from, Entity to)
        {
            Message m = GetEntityInstance<Message>();
            m.EntityFrom = from;
            m.EntityTo = to;
            return m;
        }
        public static Message GetComment(Entity from, Entity to, Message parent)
        {
            Message m = GetMessage(from, to);
            m.Parent = parent;
            return m;
        }

        public static Like GetLike(Entity e, Message m)
        {
            Like l = GetEntityInstance<Like>();
            l.Entity = e;
            l.Message = m;
            return l;
        }

        public static IDbRepository<T> GetRepositoryInstance<T>() where T : IDbEntity
        {
            return UnityHelper.RepositoryResolve<T>();
        }

        public static IService<T> GetServiceInstance<T>() where T : IDbEntity
        {
            return UnityHelper.ServiceResolve<T>();
        }

        public static U GetTOInstance<T, U>(T entity) where T:IDbEntity where U:ITO, new() {
            U to = new U();
            to.Id = entity.Id;
            return to;
        }
    }
}
