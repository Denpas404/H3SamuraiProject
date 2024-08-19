
using H3SamuraiProject.Repo.Models;

namespace H3SamuraiProject.Repo.Data;

public class DataContext : DbContext
{ 
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Samurai> Samurais { get; set; }
    public DbSet<Horse> Horses { get; set; }
    public  DbSet<Clan> Clans { get; set; }
    public DbSet<Battles> Battles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Horse>().HasData(
            new Horse { Id = 1, Name = "Red Hare", Description = "A blazing-fast horse with a mane as fiery as his name." },
            new Horse { Id = 2, Name = "ShadowFax", Description = "A majestic and mysterious steed with an air of elegance." }
        );


        modelBuilder.Entity<Clan>().HasData(
            new Clan { 
                Id = 1,
                ClanName = "Future Warriors",
                Description = "A clan of elite samurais sent from the past to protect the future, renowned for their honor and combat skills."
            },
            new Clan { 
                Id = 2,
                ClanName = "Shadow Blades",
                Description = "A mysterious clan shrouded in secrecy, known for their stealth and formidable swordsmanship."
            }
        );

        modelBuilder.Entity<Battles>().HasData(
               new Battles
               {
                   Id = 1,
                   Name = "Battle of Sekigahara",
                   Description = "The ultimate showdown in 1600 where samurais settled who was the top dog of the era, and it wasn't just a clash of swords—it was the medieval version of a big, dramatic TV finale."
               },
                new Battles
                {
                    Id = 2,
                    Name = "Battle of Nagashino",
                    Description = "The 1575 face-off where gunpowder made its grand entrance, and Takeda’s cavalry learned the hard way that 'what goes around comes around'—usually in the form of bullets."
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
            },
            new Samurai
            {
                Id = 2,
                Name = "DarkOne",
                Description = "Just another guy with sword.",
                Age = 15,
                HorseId = 2,
                ClanId = 2                
            }
        );
    }
}
