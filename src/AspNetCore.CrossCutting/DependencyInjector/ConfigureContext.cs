using AspNetCore.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.CrossCutting.DependencyInjector
{
    public static class ConfigureContext
    {
        public static void ConfigureDependencyInjector(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<MyContext>(
                options => options.UseMySql("Server=localhost;Port=3307;Database=AspNetCore;Uid=root;Pwd=1234")
            );

            // serviceCollection.AddDbContext<MyContext>(
            //     options => options.UseSqlServer("Server=localhost;Database=AspNetCore;Uid=sa;Pwd=O3!X8kEwqU")
            // );
        }
    }
}