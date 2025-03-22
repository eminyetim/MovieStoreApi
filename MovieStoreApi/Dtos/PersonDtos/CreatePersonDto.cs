using System.ComponentModel.DataAnnotations;

namespace MovieStoreApi.Dtos.PersonDto
{
    public record CreatePersonDto
    {

        public string Name { get; init; }

        public string Email { get; init; }

        public string Password { get; init; }

        public DateTime BirthDate { get; init; }

    }
}