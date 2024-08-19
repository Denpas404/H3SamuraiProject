
namespace H3SamuraiProject.Repo.Models;

public class Battles
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<SamuraiBattles>? SamuraiBattles { get; set; } // Navigation property, many-to-many (many battles to many samurais), junction table
}
