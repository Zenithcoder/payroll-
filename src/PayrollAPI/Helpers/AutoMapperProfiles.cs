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
            CreateMap<CompanyForCreationDto, Company>().ReverseMap();
            CreateMap<User, UserForDetailedDto>();
            CreateMap<CompanyForUpdateDto, Company>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<CompanyForCreationDto, Compensation>().ReverseMap();
            CreateMap<DeductionForCreationDto, Deduction>().ReverseMap();
            CreateMap<CompensationForUpdateDto, Compensation>();
            CreateMap<DeductionForUpdateDto, Deduction>();
            CreateMap<EmployeeForCreationDto, Employee>().ReverseMap();
            CreateMap<Employee, EmployeeForDetailedDto>();
        }
    }
}