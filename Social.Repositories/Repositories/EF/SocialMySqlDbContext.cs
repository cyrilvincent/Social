using Social.RepositoriesLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Repositories.EF
{
    public class SocialMySqlDbContext : DbContext
    {
        public IDbSet<Entity> Entities { get; set; }
        public IDbSet<EntityMetadata> EntityMetadatas { get; set; }
        public IDbSet<Like> Likes { get; set; }
        public IDbSet<Link> Links { get; set; }
        public IDbSet<Message> Messages { get; set; }

        static SocialMySqlDbContext()
        {
            // Désactive EdmMetaData
            Database.SetInitializer<SocialDbContext>(null);
        }

        public SocialMySqlDbContext()
            : base("Name=SocialMySqlDbContext")
        {
        }
        public SocialMySqlDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new EntityConfiguration(""));
            modelBuilder.Configurations.Add(new EntityMetadataConfiguration(""));
            modelBuilder.Configurations.Add(new LikeConfiguration(""));
            modelBuilder.Configurations.Add(new LinkConfiguration(""));
            modelBuilder.Configurations.Add(new MessageConfiguration(""));
        }
    }
}
