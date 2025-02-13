using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using MovieStoreApi.Dtos.GenreDtos;
using MovieStoreApi.Services.Abstract;
using MovieStoreApi.Services.Concrete;

namespace MovieStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresControoler : ControllerBase
    {
        private readonly IGenreService _service;

        public GenresControoler(IGenreService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<CreateGenreDto>> AddGenreDto(CreateGenreDto createGenreDto)
        {
            return await _service.AddGenreAsync(createGenreDto);
        }

        [HttpGet]
        public async Task<IEnumerable<SelectGenreDto>> GetAllGenresAsync()
        {
            return await _service.GetAllGenreAsync();
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteGenreByGuidAsync(Guid id)
        {
            return await _service.DeleteGenreAsync(id);
        }

        [HttpPut]
        public async Task<bool> UpdateGenreAsync(UpdateGenreDto genreDto)
        {
            return await _service.UpdateGenreAsync(genre: genreDto);
        }

        [HttpGet("/GenreById/{id}")]
        public async Task<SelectGenreDto?> GetByIdGenreDto(Guid id)
        {
            return await _service.GetGenreByIdAsync(id);
        }
    }
}