using Microsoft.AspNetCore.Identity;
using MovieStoreApi.Entities;
using MovieStoreApi.Repository.Context;

namespace MovieStoreApi.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static void AddIdentityExtension(this IServiceCollection services)
        {
            services.AddIdentity<Person, IdentityRole<int>>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}