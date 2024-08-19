namespace H3SamuraiProject.Repo.Models
{
    public class Horse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        //public int SamuraiId { get; set; } // Foreign key  field
        //public Samurai? Samurai { get; set; } // Navigation property, one-to-one (one horse to one samurai)

    }
}