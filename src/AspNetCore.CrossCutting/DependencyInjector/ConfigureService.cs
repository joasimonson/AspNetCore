using AspNetCore.Domain.Interfaces.Services.User;
using AspNetCore.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.CrossCutting.DependencyInjector
{
    public static class ConfigureService
    {
        public static void ConfigureDependencyInjector(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<ILoginService, LoginService>();
        }
    }
}