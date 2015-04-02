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
    public class LikeConfiguration : EntityTypeConfiguration<Like>
    {
        public LikeConfiguration(string schema = "dbo.")
        {
            ToTable(schema + "Like");
            HasKey(x => new { x.EntityId, x.MessageId });

            Property(x => x.EntityId).HasColumnName("EntityId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.MessageId).HasColumnName("MessageId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.DateTime).HasColumnName("DateTime").IsRequired();
            Ignore(x => x.Id);
            HasRequired(a => a.Entity).WithMany(b => b.Likes).HasForeignKey(c => c.EntityId);
            HasRequired(a => a.Message).WithMany(b => b.Likes).HasForeignKey(c => c.MessageId);
        }
    }
}
