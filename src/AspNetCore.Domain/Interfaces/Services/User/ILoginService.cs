using System.Threading.Tasks;
using AspNetCore.Domain.DTO;

namespace AspNetCore.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDTO user);
    }
}