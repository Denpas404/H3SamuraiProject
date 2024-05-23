
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
                new Horse { Id = 2, Name = "ShadowFax" });

          
            modelBuilder.Entity<Samurai>().HasData(
                new Samurai
                {
                    Id = 1,
                    Name = "Samurai Jack",
                    Description = "A samurai warrior who has been sent to the future by an evil demon named Aku.",
                    Age = 25,
                    HorseId = 1
                });

            modelBuilder.Entity<Samurai>().HasData(
                new Samurai
                {
                    Id = 2,
                    Name = "DarkOne",
                    Description = "Just another guy with sword.",
                    Age = 15,
                    HorseId = 2
                });

           



        }
    }
}
