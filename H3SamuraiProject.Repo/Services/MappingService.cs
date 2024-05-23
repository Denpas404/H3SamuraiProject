


namespace H3SamuraiProject.Repo.Services;

public class MappingService : IMappingService
{
    private readonly DataContext _context;

    public MappingService(DataContext dataContext)
    {
        _context = dataContext;
    }
    public SamuraiDTO MapSamurai(Samurai samurai)
    {
        var samuraiDTO = new SamuraiDTO
        {
            Name = samurai.Name,
            Description = samurai.Description,
            Horse = samurai.Horse?.Name
        };

        return samuraiDTO;
    }
}
