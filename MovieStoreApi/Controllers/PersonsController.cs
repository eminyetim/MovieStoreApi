using System.Drawing;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Dtos.PersonDto;
using MovieStoreApi.Services.Abstract;

namespace MovieStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonsController(IPersonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<SelectPersonDto>> GetAllPersonAsync()
        {
            return await _service.GetAllPersonsAsync();
        }

        [HttpPost]
        public async Task<CreatePersonDto> AddPersonAsync(CreatePersonDto createPersonDto)
        {
            return await _service.AddPersonAsync(createPersonDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePersonAsync(string email)
        {
            try
            {
                await _service.DeletePersonAsync(email);
                return Ok(new { Message = "Person successfully deleted.", PersonEmial = email});
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = "Deletion Failed",
                    Details = ex.Message,
                    Timestamp = DateTime.UtcNow
                });
            }
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<SelectPersonDto>> GetPersonByIdAsync(string email)
        {
            try
            {
                var result = await _service.GetPersonByEmailAsync(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = "Bad Request",
                    Details = ex.Message,
                    Timestamp = DateTime.UtcNow
                });
            }
        }

        [HttpPut]
        public async Task<ActionResult<UpdatePersonDto>> Update([FromBody] UpdatePersonDto updatePersonDto)
        {
            try
            {
                await _service.UpdatePersonAsync(updatePersonDto);
                return Ok(new { Message = "Person successfully Update.", PersonName = updatePersonDto.FullName });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = "Updation Failed!",
                    Details = ex.Message,
                    Timestamp = DateTime.UtcNow
                });
            }
        }
    }
}