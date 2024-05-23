

namespace H3SamuraiProject.Repo.Interfaces;

public interface IClanRepository
{
    public List<Clans> GetAllClans();
    public Clans GetClanById(int id);
    public Clans CreateClan(Clans clan);
    public Clans UpdateClan(Clans clan);
    public bool DeleteClan(Clans clan);
}
