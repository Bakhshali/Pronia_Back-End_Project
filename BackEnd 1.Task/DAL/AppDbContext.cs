using BackEnd_1.Task.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_1.Task.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Slider>Sliders { get; set; }

        public DbSet<Card>Cards { get; set; }

        public DbSet<Plant>Plants { get; set; }

        public DbSet<Color>Colors { get; set; }

        public DbSet<Size>Sizes { get; set; }

        public DbSet<PlantImage>PlantImages { get; set; }

        public DbSet <Category>Categories { get; set; }



    }
   
}
