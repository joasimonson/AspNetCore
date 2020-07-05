using AspNetCore.Domain.DTO.User;
using AspNetCore.Domain.Models;
using AutoMapper;

namespace AspNetCore.CrossCutting.Mappings
{
    public class DTOToModelProfile : Profile
    {
        public DTOToModelProfile()
        {
            CreateMap<UserDTO, UserModel>().ReverseMap();

            CreateMap<UserDTO, UserCreateDTO>().ReverseMap();

            CreateMap<UserDTO, UserUpdateDTO>().ReverseMap();
        }
    }
}