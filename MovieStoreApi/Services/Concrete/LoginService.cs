using Microsoft.AspNetCore.Identity;
using MovieStoreApi.Dtos.LoginDtos;
using MovieStoreApi.Entities;
using MovieStoreApi.Repository.Context;
using MovieStoreApi.Services.Abstract;
using System.Diagnostics.Contracts;

namespace MovieStoreApi.Services.Concrete
{
    public class LoginService : ILoginService
    {
        public readonly UserManager<Person> _userManager;

        public LoginService(UserManager<Person> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user is null)
                throw new Exception("User not found for this email.");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            return isPasswordValid;

        }
    }
}
