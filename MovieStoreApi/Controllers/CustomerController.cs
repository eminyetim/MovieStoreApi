using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Dtos.CustomerDtos;
using MovieStoreApi.Services.Abstract;

namespace MovieStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<CreateCustomerDto> AddCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            return await _service.AddCustomerAsync(createCustomerDto);
        }

        [HttpGet]
        public async Task<IEnumerable<SelectCustomerDto>> GetSelectCustomerDtosAsync()
        {
            return await _service.GetAllCustomersAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SelectCustomerDto>> GetCustomerByIdAsync(int id)
        {
            try
            {
                return await _service.GetCustomerByIdAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteCustomerById(int id)
        {
            return await _service.DeleteCustomerAsync(id);
        }

        [HttpPut]
        public async Task<bool> UpdateCustomerByUpdateCustomerDtoAsync(UpdateCustomerDto customer)
        {
            return await _service.UpdateCustomerAsync(customer);
        }

        [HttpPost("{customerId}/add-favorite-genre/{genreId}")]
        public async Task<ActionResult<bool>> AddFavoriteGenreAsync(int customerId, Guid genreId)
        {
            try
            {
                var result =  await _service.AddToGenreFavoriteForCustomerAsync(customerId,genreId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{customerId}/remove-favorite-genre/{genreId}")]
        public async Task<ActionResult<bool>> RemoveFavoriteGenreForCustomerAsync(int customerId , Guid genreId)
        {
            try
            {
                return await _service.RemoveFromGenreForCustomerAsync(customerId,genreId);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{customerId}/purchase/{movieId}")]
        public async Task<ActionResult<bool>> PurchaseMovieAsync(int customerId , int movieId)
        {
            try
            {
                return await _service.PurchaseMovieAsync(customerId,movieId);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}