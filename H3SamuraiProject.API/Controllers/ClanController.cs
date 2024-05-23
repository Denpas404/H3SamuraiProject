using Microsoft.AspNetCore.Http.HttpResults;

namespace H3SamuraiProject.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ClanController : ControllerBase
{
    private readonly IClanRepository _clanRepository;

    public ClanController(IClanRepository clanRepository)
    {
        _clanRepository = clanRepository;
    }

    [HttpGet("All")]
    public IActionResult GetAllClans()
    {
        try
        {
           var clans = _clanRepository.GetAllClans();
            if (clans == null)
            {
                return NotFound("No clans found");
            }            
            return Ok(clans);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateClan(Clans clan)
    {
        try
        {
            if (clan == null)
            {
                return BadRequest("Clan object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            var newClan = _clanRepository.CreateClan(clan);
            if (newClan == null)
            {
                return BadRequest("Failed to create a new clan");
            }

            return Ok(newClan);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }
}
