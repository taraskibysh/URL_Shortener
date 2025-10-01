using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Urs_shortener.Models.Models;

namespace Url_shortener.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UrlEntry>? Urls { get; set; } 

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<UrlEntry>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ShortCode)
                    .IsRequired()
                    .HasMaxLength(8);
                
                entity.HasIndex(e => e.ShortCode).IsUnique();

                entity.Property(e => e.OriginalUrl)
                    .IsRequired()
                    .HasMaxLength(2048); 

                entity.HasIndex(e => e.UserId);
            });
            
        }
    }
}