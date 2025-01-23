using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Dtos.PersonDto;
using MovieStoreApi.Services.Abstract;

namespace MovieStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonAsync(int id)
        {
            try
            {
                await _service.DeletePersonAsync(id);
                return Ok(new { Message = "Person successfully deleted.", PersonId = id });
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
        public async Task<ActionResult<SelectPersonDto>> GetPersonByIdAsync(int id)
        {
            try
            {
                var result = await _service.GetPersonByIdAsync(id);
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
                return Ok(new { Message = "Person successfully Update.", PersonName = updatePersonDto.Name });
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