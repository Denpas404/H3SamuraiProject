
namespace H3SamuraiProject.Repo.Models;

public class Samurai
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }    
    public int Age { get; set; }

    public int? HorseId { get; set; } // foreign key field
    public Horse? Horse { get; set; } // navigation property, one-to-one (one samurai to one horse)

    public int? ClanId { get; set; } // foreign key field
    public Clan? Clan { get; set; }  // navigation property, many-to-one (many samurais to one clan)
    public List<SamuraiBattles>? SamuraiBattles { get; set; } // navigation property, many-to-many (many samurais to many battles), junction table
}
