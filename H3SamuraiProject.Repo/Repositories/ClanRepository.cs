
namespace H3SamuraiProject.Repo.Repositories;

public class ClanRepository : IClanRepository
{
    private readonly DataContext _context;

    public ClanRepository(DataContext context)
    {
        _context = context;
    }

    public Clans CreateClan(Clans clan)
    {
        _context.Clans.Add(clan);
        _context.SaveChanges();
        return clan;
    }

    public bool DeleteClan(Clans clan)
    {
        throw new NotImplementedException();
    }

    public List<Clans> GetAllClans()
    {
        return _context.Clans.ToList();
    }

    public Clans GetClanById(int id)
    {
        throw new NotImplementedException();
    }

    public Clans UpdateClan(Clans clan)
    {
        throw new NotImplementedException();
    }
}
