using BackEnd_1.Task.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_1.Task.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Setting>()
            .HasIndex(u=>u.Key)
            .IsUnique();
            base.OnModelCreating(builder);
        }

        public DbSet<Slider>Sliders { get; set; }

        public DbSet<Card>Cards { get; set; }

        public DbSet<Plant>Plants { get; set; }

        public DbSet<Color>Colors { get; set; }

        public DbSet<Size>Sizes { get; set; }

        public DbSet<PlantImage>PlantImages { get; set; }

        public DbSet <Category>Categories { get; set; }

        public DbSet<PlantCategory>PlantCategories { get; set; }

        public DbSet<Setting> Settings { get; set; }


    }
   
}
