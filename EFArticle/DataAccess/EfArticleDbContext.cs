using EFArticle.DataAccess.EFConfiguration;
using EFArticle.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFArticle.DataAccess
{
    public class EfArticleDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        
        public EfArticleDbContext(DbContextOptions<EfArticleDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
        }
    }
}
