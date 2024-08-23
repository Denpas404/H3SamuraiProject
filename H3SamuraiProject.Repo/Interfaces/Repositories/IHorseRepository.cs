namespace H3SamuraiProject.Repo.Interfaces.Repositories
{
    public interface IHorseRepository
    {
        public Horse Create(Horse horse);
        public Horse GetHorseById(int id);
        public ICollection<Horse> GetAllHorses();
        public Horse Update(Horse horse);
        public bool Delete(Horse horse);
    }
}
