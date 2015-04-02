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
    public class LinkConfiguration : EntityTypeConfiguration<Link>
    {
        public LinkConfiguration(string schema = "dbo.")
        {
            ToTable(schema + "Link");
            HasKey(x => new { x.EntityIdFrom, x.EntityIdTo, x.Type });

            Property(x => x.EntityIdFrom).HasColumnName("EntityIdFrom").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.EntityIdTo).HasColumnName("EntityIdTo").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Type).HasColumnName("TypeId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.DateTime).HasColumnName("DateTime").IsRequired();
            Property(x => x.MessageId).HasColumnName("MessageId").IsOptional();
            Property(x => x.Status).HasColumnName("Status").IsRequired();
            Ignore(x => x.Id);

            HasRequired(a => a.EntityFrom).WithMany(b => b.FromLinks).HasForeignKey(c => c.EntityIdFrom);
            HasRequired(a => a.EntityTo).WithMany(b => b.ToLinks).HasForeignKey(c => c.EntityIdTo);
            HasOptional(a => a.Message).WithMany(b => b.Links).HasForeignKey(c => c.MessageId);
        }
    }
}
