using System.Linq;
using AutoMapper;
using PayrollAPI.Dtos;
using PayrollAPI.Models;

namespace PayrollAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
           CreateMap<User, UserForListDto>();
                 
            CreateMap<User, UserForDetailedDto>();
                 
         //   CreateMap<UserForUpdateDto, User>();
             CreateMap<UserForRegisterDto, User>();
        }
    }
}