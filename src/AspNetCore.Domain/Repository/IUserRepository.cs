using System.Threading.Tasks;
using AspNetCore.Domain.Entities;
using AspNetCore.Domain.Interfaces;

namespace AspNetCore.Domain.Repository
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string login);
    }
}