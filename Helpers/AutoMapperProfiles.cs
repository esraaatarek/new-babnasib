using Api.Entities;
using Api.DTOs;
using AutoMapper;

namespace Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // add lines
            CreateMap<AddUserDTO, User>();
            CreateMap<User, UserDTO>();
           // CreateMap<, >();
        }
    }
}