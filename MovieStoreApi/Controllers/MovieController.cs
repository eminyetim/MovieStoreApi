using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Dtos.MovieActorsDtos;
using MovieStoreApi.Dtos.MovieDtos;
using MovieStoreApi.Services.Abstract;

namespace MovieStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<CreateMovieDto> AddMovieAsync(CreateMovieDto createMovieDto)
        {
            return await _service.AddMovieAsync(createMovieDto);
        }

        [HttpGet]
        public async Task<IEnumerable<SelectMovieDto>> GetAllMovieAsync()
        {
            return await _service.GetAllMovieAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SelectMovieDto?>> GetMovieByIdAsync(int id)
        {
            try
            {
                return await _service.GetMovieByIdAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateMovieAsync(UpdateMovieDto movie)
        {
            try
            {
                return await _service.UpdateMovieAsync(movie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteMovieAsync(int id)
        {
            try
            {
                return await _service.DeleteMovieAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("actors")]
        public async Task<ActionResult<bool>> AddActorsToMovie([FromBody] AddMovieActorsDto dto)
        {
            try
            {
                return await _service.AddActorsToMovie(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{movieId}/add-to-Genre/{genreId}")]
        public async Task<ActionResult<bool>> AddGenreForMovie(int movieId, Guid genreId)
        {
            try
            {
                return await _service.AddToGenreForMovie(movieId, genreId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{movieId}/remove-genre/{genreId}")]
        public async Task<ActionResult<bool>> RemoveMovieGenre(int movieId, Guid genreId)
        {
            try
            {
                return await _service.RemoveFromGenreForMovie(movieId, genreId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}