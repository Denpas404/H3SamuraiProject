
namespace H3SamuraiProject.Repo.Models;

public class Clan
{
    public int Id { get; set; }
    public required string ClanName { get; set; }
    public string? Description { get; set; }
    public List<Samurai>? Samurais { get; set; }  // Navigation property, one-to-many (one clan to many samurais)
}
