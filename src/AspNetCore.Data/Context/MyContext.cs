using AspNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Data.Context {
    public class MyContext : DbContext {
        public MyContext (DbContextOptions<MyContext> options) : base (options) { }
        public DbSet<UserEntity> Users { get; set; }
    }
}