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
        public async Task<bool> UpdateCustomerByUpdateCustomerDto(UpdateCustomerDto customer)
        {
            return await _service.UpdateCustomerAsync(customer);
        }

        [HttpPost("{customerId}/add-favorite-genre/{genreId}")]
        public async Task<ActionResult<bool>> AddFavoriteGenre(int customerId, Guid genreId)
        {
            try
            {
                var result =  await _service.AddToGenreFavoriteForCustomer(customerId,genreId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{customerId}/remove-favorite-genre/{genreId}")]
        public async Task<ActionResult<bool>> RempveFavoriteGenreForCustomer(int customerId , Guid genreId)
        {
            try
            {
                return await _service.RemoveFromGenreForCustomer(customerId,genreId);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}