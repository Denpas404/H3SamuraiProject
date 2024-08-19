namespace H3SamuraiProject.Repo.Models;

public class SamuraiBattles 
{
    public int Id { get; set; }
    public int SamuraiId { get; set; } // Foreign key field
    public Samurai? Samurai { get; set; } // Navigation property, 
    public int BattleId { get; set; } // Foreign key field
    public Battles? Battle { get; set; } // Navigation property
}
