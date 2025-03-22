using MovieStoreApi.Dtos.LoginDtos;

namespace MovieStoreApi.Services.Abstract
{
    public interface ILoginService
    {
        Task<bool> LoginAsync(LoginDto loginDto);
    }
}
