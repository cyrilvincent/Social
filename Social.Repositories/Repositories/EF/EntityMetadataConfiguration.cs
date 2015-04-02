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
    public class EntityMetadataConfiguration : EntityTypeConfiguration<EntityMetadata>
    {
        public EntityMetadataConfiguration(string schema = "dbo.")
        {
            ToTable(schema + "EntityMetadata");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Pseudo).HasColumnName("Pseudo").IsOptional().HasMaxLength(50);
            Property(x => x.ShortName).HasColumnName("ShortName").IsOptional().HasMaxLength(50);
            Property(x => x.LongName).HasColumnName("LongName").IsOptional().HasMaxLength(255);
            Property(x => x.Mail).HasColumnName("Mail").IsOptional().HasMaxLength(100);
            Property(x => x.Pwd).HasColumnName("Pwd").IsOptional().HasMaxLength(255);
            Property(x => x.DateTime).HasColumnName("DateTime").IsRequired();
            Property(x => x.FName).HasColumnName("FName").IsOptional().HasMaxLength(50);
            Property(x => x.LName).HasColumnName("LName").IsOptional().HasMaxLength(100);
            Property(x => x.MName).HasColumnName("MName").IsOptional().HasMaxLength(50);
            Property(x => x.Description).HasColumnName("Description").IsOptional().HasMaxLength(255);
            Property(x => x.Text).HasColumnName("Text").IsOptional();
            Property(x => x.Address1).HasColumnName("Address1").IsOptional().HasMaxLength(50);
            Property(x => x.Address2).HasColumnName("Address2").IsOptional().HasMaxLength(50);
            Property(x => x.Address3).HasColumnName("Address3").IsOptional().HasMaxLength(50);
            Property(x => x.ZipCode).HasColumnName("ZipCode").IsOptional().HasMaxLength(50);
            Property(x => x.City).HasColumnName("City").IsOptional().HasMaxLength(100);
            Property(x => x.State).HasColumnName("State").IsOptional().HasMaxLength(50);
            Property(x => x.Country).HasColumnName("Country").IsOptional().HasMaxLength(50);
            Property(x => x.Phone1).HasColumnName("Phone1").IsOptional().HasMaxLength(20);
            Property(x => x.Phone2).HasColumnName("Phone2").IsOptional().HasMaxLength(20);
            Property(x => x.Internet).HasColumnName("Internet").IsOptional().HasMaxLength(100);
            Property(x => x.Ip).HasColumnName("Ip").IsOptional().HasMaxLength(11);
        }
    }
}
