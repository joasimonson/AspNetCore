using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.Domain.DTO.User;

namespace AspNetCore.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDTO> Get(Guid id);

        Task<IEnumerable<UserDTO>> GetAll();

        Task<UserCreatedDTO> Post(UserCreateDTO user);

        Task<UserUpdatedDTO> Put(UserUpdateDTO user);

        Task<bool> Delete(Guid id);
    }
}