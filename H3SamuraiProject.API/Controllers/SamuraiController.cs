﻿
namespace H3SamuraiProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SamuraiController : ControllerBase
    {
        private readonly ISamuraiRepository _samuraiRepository;

        public SamuraiController(ISamuraiRepository samuraiRepository)
        {
            _samuraiRepository = samuraiRepository;
        }

        [HttpPost]
        public IActionResult CreateSamurai(Samurai samurai)
        {
            try
            {
                if (samurai == null)
                {
                    return BadRequest("Samurai object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var newSamurai = _samuraiRepository.Create(samurai);

                if (newSamurai == null)
                {
                    return BadRequest("Failed to create a new samurai");
                }

                return Ok(newSamurai);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [HttpGet]
        public IActionResult GetAllSamurais()
        {
            try
            {
                var samurais = _samuraiRepository.GetAllSamurais();
                
                if (samurais == null)
                {
                    return NotFound("No samurais found");
                }

                return Ok(samurais);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSamuraiById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid id");
                }

                var samurai = _samuraiRepository.GetSamuraiById(id);

                if (samurai == null)
                {
                    return NotFound($"Samurai with id {id} not found");
                }

                return Ok(samurai);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateSamurai(Samurai samurai)
        {
            try
            {
                if (samurai == null)
                {
                    return BadRequest("Samurai object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var updatedSamurai = _samuraiRepository.Update(samurai);

                if (updatedSamurai == null)
                {
                    return BadRequest("Failed to update samurai");
                }

                return Ok(updatedSamurai);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSamurai(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid id");
                }

                var samurai = _samuraiRepository.GetSamuraiById(id);

                if (samurai == null)
                {
                    return NotFound($"Samurai with id {id} not found");
                }

                var deleted = _samuraiRepository.Delete(samurai);

                if (!deleted)
                {
                    return BadRequest("Failed to delete samurai");
                }

                return Ok("Samurai deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
