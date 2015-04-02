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
    public class MessageConfiguration : EntityTypeConfiguration<Message>
    {
        public MessageConfiguration(string schema = "dbo.")
        {
            ToTable(schema + "Message");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.EntityIdFrom).HasColumnName("EntityIdFrom").IsRequired();
            Property(x => x.EntityIdTo).HasColumnName("EntityIdTo").IsRequired();
            Property(x => x.Type).HasColumnName("TypeId").IsRequired();
            Property(x => x.DateTime).HasColumnName("DateTime").IsRequired();
            Property(x => x.Visibility).HasColumnName("VisibilityId").IsRequired();
            Property(x => x.Tags).HasColumnName("Tags").IsOptional().HasMaxLength(50);
            Property(x => x.Text).HasColumnName("Text").IsRequired().HasMaxLength(4000);
            Property(x => x.Title).HasColumnName("Title").IsOptional().HasMaxLength(100);
            Property(x => x.ParentId).HasColumnName("MessageId").IsOptional();
            Property(x => x.LongText).HasColumnName("LongText").IsOptional();
            Property(x => x.Description).HasColumnName("Description").IsOptional().HasMaxLength(500);
            Property(x => x.Url).HasColumnName("Url").IsOptional().HasMaxLength(255);
            Property(x => x.ImageUrl).HasColumnName("ImageUrl").IsOptional().HasMaxLength(255);
            Property(x => x.VideoUrl).HasColumnName("VideoUrl").IsOptional().HasMaxLength(255);

            HasRequired(a => a.EntityFrom).WithMany(b => b.FromMessages).HasForeignKey(c => c.EntityIdFrom);
            HasRequired(a => a.EntityTo).WithMany(b => b.ToMessages).HasForeignKey(c => c.EntityIdTo);
            HasOptional(a => a.Parent).WithMany(b => b.Childrens).HasForeignKey(c => c.ParentId);
        }
    }
}
