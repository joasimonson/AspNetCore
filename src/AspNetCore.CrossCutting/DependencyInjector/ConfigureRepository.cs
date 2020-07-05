using AspNetCore.Data.Repository;
using AspNetCore.Domain.Interfaces;
using AspNetCore.Domain.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.CrossCutting.DependencyInjector
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependencyInjector(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            serviceCollection.AddScoped(typeof(IUserRepository), typeof(UserRepository));
        }
    }
}