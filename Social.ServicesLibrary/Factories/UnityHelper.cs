using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using System.Reflection;
using System.Data.Entity;
using Social.RepositoriesLibrary.Entities.Common;
using Social.RepositoriesLibrary.Repositories.Common;
using Social.ServicesLibrary.Services.Common;

namespace Social.ServicesLibrary.Factories
{
    public static class UnityHelper
    {
        private static IUnityContainer container;

        public static void Configure()
        {
            var dataSet = ConfigurationManager.GetSection("system.data") as System.Data.DataSet;
            dataSet.Tables[0].Rows.Add("MySQL Data Provider", "Provider Description", "MySql.Data.MySqlClient", "MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data, Version=6.8.3.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d");
            container = new UnityContainer();
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(container);
            Configuration();
        }

        public static IUnityContainer Container
        {
            get
            {
                if (container == null) Configure();
                return container;
            }
        }

        private static void Configuration()
        {
            EntityAutoRegister();
            RepositoryAutoRegister();
            ServiceAutoRegister();
        }

        private static void EntityAutoRegister()
        {
            EntityAutoRegister(typeof(IDbEntity).Assembly);
        }

        private static void EntityAutoRegister(Assembly assembly)
        {
            IEnumerable<Type> ie = assembly.GetTypes().Where(t => t.GetInterface(typeof(IDbEntity).FullName) != null && !t.IsAbstract);
            foreach (Type t in ie)
            {
                container.RegisterType(typeof(IDbEntity), t, t.Name);
            }
        }

        private static void RepositoryAutoRegister()
        {
            RepositoryAutoRegister(typeof(IDbRepository<>).Assembly);
        }

        private static void RepositoryAutoRegister(Assembly assembly)
        {
            IEnumerable<Type> ie = assembly.GetTypes().Where(t => t.GetInterface(typeof(IDbRepository<>).FullName) != null && !t.IsAbstract); // pour les repository non dbcontext
            foreach (Type t in ie)
            {
                RepositoryRegisterType(t);
            }
        }

        private static IUnityContainer RepositoryRegisterType(Type t)
        {
            Type iType = t.GetInterfaces().Where(i => i.Name == typeof(IDbRepository<>).Name).First();
            return container.RegisterType(iType, t, new InjectionProperty("DbContext"));
        }


        private static void ServiceAutoRegister()
        {
            ServiceAutoRegister(typeof(IService<>).Assembly);
        }

        private static void ServiceAutoRegister(Assembly assembly)
        {
            IEnumerable<Type> ie = assembly.GetTypes().Where(t => t.GetInterface(typeof(IService<>).FullName) != null && !t.IsAbstract);
            foreach (Type t in ie)
            {
                ServiceRegisterType(t);
            }
        }

        private static IUnityContainer ServiceRegisterType(Type t)
        {
            Type iType = t.GetInterfaces().Where(i => i.Name == typeof(IService<>).Name).First();
            return Container.RegisterType(iType, t, new InjectionProperty("Repository"));
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        private static T Resolve<T, U>()
        {
            return Container.Resolve<T>(typeof(U).Name);
        }

        public static IDbEntity EntityResolve<T>() where T : IDbEntity
        {
            return Resolve<IDbEntity, T>();
        }

        public static IDbRepository<T> RepositoryResolve<T>() where T : IDbEntity
        {
            return Resolve<IDbRepository<T>>();
        }

        public static IService<T> ServiceResolve<T>() where T : IDbEntity
        {
            return Resolve<IService<T>>();
        }

        /// <summary>
        /// Debug
        /// </summary>
        /// <returns></returns>
        public static string Debug()
        {
            string s = "";
            foreach (ContainerRegistration cr in Container.Registrations)
            {
                s += "From " + cr.RegisteredType.ToString() + " to " + cr.MappedToType.ToString() + " [" + cr.Name + "] in " + cr.LifetimeManagerType.ToString() + Environment.NewLine;
            }
            return s;
        }
    }
}
