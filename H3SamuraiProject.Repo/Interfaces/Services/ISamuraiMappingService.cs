
namespace H3SamuraiProject.Repo.Interfaces.Services;

public interface ISamuraiMappingService
{

    public Samurai MapSamurai(Samurai samurai);
    public List<Samurai> MapSamurais(List<Samurai> samurais);
}
