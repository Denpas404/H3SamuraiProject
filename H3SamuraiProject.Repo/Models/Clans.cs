

namespace H3SamuraiProject.Repo.Models
{
    public class Clans
    {
        public int Id { get; set; }
        public string ClanName { get; set; }
        public string ClanDescription { get; set; }

        public int ClanLeaderId { get; set; }
        public Samurai? ClanLeader { get; set; }
        public ICollection<Samurai>? Samurais { get; set; }  
    }
}
