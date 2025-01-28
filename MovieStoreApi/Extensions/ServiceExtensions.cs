using MovieStoreApi.Services.Abstract;
using MovieStoreApi.Services.Concrete;

namespace MovieStoreApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddServiceExtension(this IServiceCollection services)
        {
            services.AddScoped<IPersonService,PersonService>();
            services.AddScoped<IActorService,ActorService>();
            services.AddScoped<IDirectorService,DirectorService>();
        }
    }
}