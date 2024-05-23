
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
        public DbSet<Clans> Clans { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Horse>().HasData(
                new Horse { Id = 1, Name = "Red Hare" },
                new Horse { Id = 2, Name = "ShadowFax" });

            modelBuilder.Entity<Clans>().HasData(
                new Clans
                {
                    Id = 1,
                    ClanName = "Shogun",
                    ClanDescription = "The Shogun Clan is the most powerful clan in the land.",
                    ClanLeaderId = 1
                },
                new Clans
                {
                    Id = 2,
                    ClanName = "Ronin",
                    ClanDescription = "The Ronin Clan is a group of masterless samurai.",
                    ClanLeaderId = 2
                }
                );



            modelBuilder.Entity<Samurai>().HasData(
                new Samurai
                {
                    Id = 1,
                    Name = "Samurai Jack",
                    Description = "A samurai warrior who has been sent to the future by an evil demon named Aku.",
                    Age = 25,
                    HorseId = 1,
                    ClanId = 1
                });

            modelBuilder.Entity<Samurai>().HasData(
                new Samurai
                {
                    Id = 2,
                    Name = "DarkOne",
                    Description = "Just another guy with sword.",
                    Age = 15,
                    HorseId = 2,
                    ClanId = 2
                });

            modelBuilder.Entity<Clans>()
              .HasOne(c => c.ClanLeader)
              .WithOne(s => s.Clan)
              .HasForeignKey<Clans>(c => c.ClanLeaderId);



        }
    }
}
