
namespace H3SamuraiProject.Repo.Models
{
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
        public int? HorseId { get; set; } // foreign key field
        public Horse? Horse { get; set; } // navigation property

        public int? ClanId { get; set; }
        public Clan? Clan { get; set; }
    }
}
