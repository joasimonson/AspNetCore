using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.Domain.DTO.User;
using AspNetCore.Domain.Entities;
using AspNetCore.Domain.Interfaces;
using AspNetCore.Domain.Interfaces.Services.User;
using AspNetCore.Domain.Models;
using AutoMapper;

namespace AspNetCore.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IBaseRepository<UserEntity> userRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
        }

        public async Task<UserDTO> Get(Guid id)
        {
            var entity = await _userRepository.SelectAsync(id);
            var dto = _mapper.Map<UserDTO>(entity);
            return dto;
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var listEntity = await _userRepository.SelectAsync();
            var listDto = _mapper.Map<IEnumerable<UserDTO>>(listEntity);
            return listDto;
        }

        public async Task<UserCreatedDTO> Post(UserCreateDTO user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _userRepository.InsertAsync(entity);
            var dto = _mapper.Map<UserCreatedDTO>(result);
            return dto;
        }

        public async Task<UserUpdatedDTO> Put(UserUpdateDTO user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _userRepository.UpdateAsync(entity);
            var dto = _mapper.Map<UserUpdatedDTO>(result);
            return dto;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _userRepository.DeleteAsync(id);
        }
    }
}