using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Dtos.DirectorDtos;
using MovieStoreApi.Services.Abstract;

namespace MovieStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _director;

        public DirectorController(IDirectorService director)
        {
            _director = director;
        }

        [HttpPost]
        public async Task<ActionResult<CreateDirectorDto>> AddDirectorAsyn(CreateDirectorDto director)
        {
            return await _director.AddDirectorAsync(director);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteDirector(int id)
        {
            try
            {
                return await _director.DeleteDirectorAsync(id);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IEnumerable<SelectDirectorDto>> GetAllDirectorsAsync()
        {
            return await _director.GetAllDirectorsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SelectDirectorDto?>> GetByIdDirectorAsync(int id)
        {
            try
            {
                return await _director.GetDirectorByIdAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateDirectorAsync(UpdateDirectorDto updateDirector)
        {
            return await _director.UpdateDirectorAsync(updateDirector);
        }
    }
}