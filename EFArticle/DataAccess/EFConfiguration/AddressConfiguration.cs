using System;
using EFArticle.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFArticle.DataAccess.EFConfiguration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("addresses");

            builder.HasKey(address => address.Id);

            builder.Property<Guid>("_personId")
                .HasColumnName("id_person")
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();

            builder.HasOne<Person>()
                .WithMany(nameof(Person.Address))
                .HasForeignKey("_personId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(address => address.Id)
                .HasColumnName("id")
                .HasColumnType("UNIQUEIDENTIFIER");

            builder.Property(address => address.City)
                .HasColumnName("city")
                .HasColumnType("VARCHAR(40)")
                .IsRequired();
            
            builder.Property(address => address.Street)
                .HasColumnName("street")
                .HasColumnType("VARCHAR(120)")
                .IsRequired();
            
            builder.Property(address => address.Number)
                .HasColumnName("number")
                .HasColumnType("VARCHAR(20)")
                .IsRequired();
        }
    }
}