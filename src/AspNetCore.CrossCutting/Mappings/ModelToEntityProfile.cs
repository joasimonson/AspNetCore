using AspNetCore.Domain.Entities;
using AspNetCore.Domain.Models;
using AutoMapper;

namespace AspNetCore.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserModel, UserEntity>().ReverseMap();
        }
    }
}