
using H3SamuraiProject.Repo.Models;

namespace H3SamuraiProject.Repo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Horse> Horses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Horse>().HasData(
                new Horse { Id = 1, Name = "Red Hare" },
                new Horse { Id = 2, Name = "ShadowFax" },
                new Horse { Id = 3, Name = "Black Beauty" },
                new Horse { Id = 4, Name = "Silver" }
                );
                

            //Create 4 samurais with unik and funny Names  and descriptions
            modelBuilder.Entity<Samurai>().HasData(
                new Samurai { Id = 1,
                    Name = "Samurai Jack",
                    Description = "A samurai warrior who has been sent to the future by the evil demon Aku",
                    HorseId = 1
                },
                new Samurai { Id = 2,
                    Name = "DarkOne",
                    Description = "Just another guy with sword.",
                    HorseId = 2
                },
                new Samurai
                {
                    Id = 3,
                    Name = "Ronin Ron",
                    Description = "A wandering samurai with a heart of gold and a knack for getting into trouble",
                    HorseId = 3
                },
                new Samurai
                {
                    Id = 4,
                    Name = "Lazy Blade Larry",
                    Description = "A samurai who prefers lounging around to sword fighting, but still manages to get the job done",
                    HorseId = 4
                }
                );

        }
    }
}
