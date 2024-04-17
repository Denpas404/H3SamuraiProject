
namespace H3SamuraiProject.Repo.Repositories
{
    public class SamuraiRepository : ISamuraiRepository
    {
        private readonly DataContext _context;

        public SamuraiRepository(DataContext context)
        {
            _context = context;
        }
        public Samurai Create(Samurai samurai)
        {
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
            return samurai;
        }

        public bool Delete(Samurai samurai)
        {
            _context.Samurais.Remove(samurai);
            int saved = _context.SaveChanges();
            return saved < 0;
        }

        public ICollection<Samurai> GetAllSamurais()
        {
            return _context.Samurais.OrderBy(S => S.Name).ToList();
        }

        public Samurai GetSamuraiById(int id)
        {
            return _context.Samurais.FirstOrDefault(S => S.Id == id);
        }

        public Samurai Update(Samurai samurai)
        {
            _context.Samurais.Update(samurai);
            _context.SaveChanges();
            return samurai;
        }
    }
}
