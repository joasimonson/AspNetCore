using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AspNetCore.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            /* Conexão pelo MySQL */
            const string connectionString = "Server=localhost;Port=3306;Database=AspNetCore;Uid=root;Pwd=O3!X8kEwqU";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(connectionString);

            /* Conexão pelo SQL Server */
            // const string connectionString = "Server=localhost;Database=AspNetCore;Uid=sa;Pwd=O3!X8kEwqU";
            // var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            // optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}