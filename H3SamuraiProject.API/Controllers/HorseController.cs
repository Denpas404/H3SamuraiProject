

using H3SamuraiProject.Repo.Interfaces.Repositories;

namespace H3SamuraiProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorseController : ControllerBase
    {
        private readonly IHorseRepository _horseRepository;

        public HorseController(IHorseRepository horseRepository)
        {
            _horseRepository = horseRepository;
        }

        [HttpPost]
        public IActionResult CreateHorse(Horse horse)
        {
            try
            {
                if (horse == null)
                {
                    return BadRequest("Horse object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var newHorse = _horseRepository.Create(horse);

                if (newHorse == null)
                {
                    return BadRequest("Failed to create a new horse");
                }

                return Ok(newHorse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("All")]
        public IActionResult GetHorses()
        {
            try
            {                               
                var horses = _horseRepository.GetAllHorses();
                
                if (horses == null)
                {
                    return NotFound();
                }
                return Ok(horses);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetHorseById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid horse id");
                }

                var horse = _horseRepository.GetHorseById(id);

                if (horse == null)
                {
                    return NotFound();
                }
                return Ok(horse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Horse horse)
        {
            try
            {
                if (horse == null)
                {
                    return BadRequest("Horse object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var updatedHorse = _horseRepository.Update(horse);

                if (updatedHorse == null)
                {
                    return BadRequest("Failed to update horse");
                }

                return Ok(updatedHorse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid horse id");
                }

                var horse = _horseRepository.GetHorseById(id);

                if (horse == null)
                {
                    return NotFound();
                }

                var deleted = _horseRepository.Delete(horse);

                if (!deleted)
                {
                    return BadRequest("Failed to delete horse");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
