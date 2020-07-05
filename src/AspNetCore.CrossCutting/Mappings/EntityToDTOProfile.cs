using AspNetCore.Domain.DTO.User;
using AspNetCore.Domain.Entities;
using AutoMapper;

namespace AspNetCore.CrossCutting.Mappings
{
    public class EntityToDTOProfile : Profile
    {
        public EntityToDTOProfile()
        {
            CreateMap<UserEntity, UserDTO>().ReverseMap();

            CreateMap<UserEntity, UserCreatedDTO>().ReverseMap();

            CreateMap<UserEntity, UserUpdatedDTO>().ReverseMap();
        }
    }
}