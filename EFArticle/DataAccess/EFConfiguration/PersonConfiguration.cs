using EFArticle.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFArticle.DataAccess.EFConfiguration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("persons");
            
            builder.HasKey(person => person.Id);

            builder.Property(person => person.Id)
                .HasColumnName("id")
                .HasColumnType("UNIQUEIDENTIFIER");
            
            builder.Property(person => person.Name)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(120)")
                .IsRequired();

            builder.OwnsOne(person => person.Document, documentConfiguration =>
            {
                documentConfiguration.Property(document => document.UniqueIdentifierRegister)
                    .HasColumnName("doc_unique_identifier_register")
                    .HasColumnType("VARCHAR(11)")
                    .IsRequired();

                documentConfiguration.Property(document => document.DriveLicence)
                    .HasColumnName("doc_drive_licence")
                    .HasColumnType("VARCHAR(20)");
            });
        }
    }
}