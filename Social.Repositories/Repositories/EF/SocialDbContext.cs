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
    public class SocialDbContext : DbContext
    {
        public IDbSet<Entity> Entities { get; set; }
        public IDbSet<EntityMetadata> EntityMetadatas { get; set; }
        public IDbSet<Like> Likes { get; set; }
        public IDbSet<Link> Links { get; set; }
        public IDbSet<Message> Messages { get; set; }

        static SocialDbContext()
        {
            // Désactive EdmMetaData
            Database.SetInitializer<SocialDbContext>(null);
            Database.SetInitializer<SocialDbContext>(new CreateDatabaseIfNotExists<SocialDBContext>());
            
        }

        public SocialDbContext()
            : base("Name=SocialDbContext")
        {
        }
        public SocialDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Hit only one type because the dcm is cached the first time
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new EntityConfiguration());
            modelBuilder.Configurations.Add(new EntityMetadataConfiguration());
            modelBuilder.Configurations.Add(new LikeConfiguration());
            modelBuilder.Configurations.Add(new LinkConfiguration());
            modelBuilder.Configurations.Add(new MessageConfiguration());

        }
    }
}
