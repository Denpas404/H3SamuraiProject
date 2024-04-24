
namespace H3SamuraiProject.Repo.Models
{
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public int? HorseId { get; set; }
        public Horse? Horse { get; set; }
    }
}
