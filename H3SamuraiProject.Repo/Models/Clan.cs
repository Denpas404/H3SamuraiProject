
namespace H3SamuraiProject.Repo.Models;

public class Clan
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Samurai> Samurais { get; set; }
}
