
namespace H3SamuraiProject.Repo.Models;

public class Clan
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ClanLeaderId { get; set; } // foreign key field to Samurai
    public Samurai ClanLeader { get; set; } // navigation property
    public ICollection<Samurai> Samurais { get; set; } // navigation property
}
