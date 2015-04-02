using Social.RepositoriesLibrary.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Repositories.EF
{
    public class EntityConfiguration : EntityTypeConfiguration<Entity>
    {
        public EntityConfiguration(string schema = "dbo.")
        {
            ToTable(schema + "Entity");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.MetaDataId).HasColumnName("MetaDataId").IsRequired();
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            Property(x => x.Bannished).HasColumnName("Bannished").IsRequired();
            Property(x => x.Type).HasColumnName("TypeId").IsRequired();
            Property(x => x.Visibility).HasColumnName("VisibilityId").IsRequired();

            HasRequired(a => a.Metadata).WithMany(b => b.Entities).HasForeignKey(c => c.MetaDataId);
        }
    }
}
