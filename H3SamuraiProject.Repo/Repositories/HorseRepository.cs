
using H3SamuraiProject.Repo.Data;
using H3SamuraiProject.Repo.Interfaces;

namespace H3SamuraiProject.Repo.Repositories
{
    public class HorseRepository : IHorseRepository
    {
        private readonly DataContext _context;

        public HorseRepository(DataContext context) 
        { 
            _context = context;
        }
        public Horse Create(Horse horse)
        {
            _context.Horses.Add(horse);
            _context.SaveChanges();
            return horse;
        }

        public bool Delete(Horse horse)
        {
            _context.Horses.Remove(horse);
            int saved = _context.SaveChanges();
            return saved < 0;
        }

        public ICollection<Horse> GetAllHorses()
        {
            return _context.Horses.OrderBy(H => H.Name).ToList();
        }

        public Horse GetHorseById(int id)
        {
            return _context.Horses.FirstOrDefault(H => H.Id == id);
        }

        public Horse Update(Horse horse)
        {
            _context.Horses.Update(horse);
            _context.SaveChanges();
            return horse;
        }
    }
}
