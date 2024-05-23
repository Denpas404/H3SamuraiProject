

namespace H3SamuraiProject.Repo.Interfaces;

public interface ISamuraiRepository
{
    public Samurai Create(Samurai samurai);
    public Samurai GetSamuraiById(int id);
    public ICollection<Samurai> GetAllSamurais();
    public Samurai Update(Samurai samurai);
    public bool Delete(Samurai samurai);

}
