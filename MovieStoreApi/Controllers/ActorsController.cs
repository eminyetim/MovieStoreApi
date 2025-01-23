using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Dtos.ActorDtos;
using MovieStoreApi.Entities;
using MovieStoreApi.Services.Abstract;

namespace MovieStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _service;

        public ActorsController(IActorService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<CreateActorDto>> AddActorAsync(CreateActorDto createActorDto)
        {
            return await _service.AddActorAsync(createActorDto);
        }

        [HttpGet]
        public async Task<IEnumerable<SelectActorDto>> GetAllActorAsync()
        {
            return await _service.GetAllActorsAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SelectActorDto>> GetActorAsync(int id)
        {
            var result = await _service.GetActorByIdAsync(id);
            if (result == null)
                return BadRequest("Actor is could not be find!");
            return result;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateActor([FromBody] UpdateActorDto updateActorDto)
        {
            try
            {
                var updatedActor = await _service.UpdateActorAsync(updateActorDto);
                if (updatedActor == null)
                {
                    return NotFound(new { Message = "Actor not found." });
                }
                return Ok(updatedActor); // Güncellenen Actor döner
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            try
            {
                var isDeleted = await _service.DeleteActor(id);

                if (!isDeleted)
                {
                    return NotFound(new { Message = "Actor not found." });
                }

                // Başarıyla silinmişse 204 No Content döndür
                return NoContent();
            }
            catch (Exception ex)
            {
                // Hata durumunda 400 Bad Request döndür
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}