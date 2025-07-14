using BirthdaylistAPI;
using BirthdaylistAPI.Models;
using AutoMapper;
using BirthdaylistAPI.DTOs;
namespace BirthdaylistAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Birthdaylist, BirthdaylistDTO>();
            CreateMap<Birthdaylist, BirthdaylistDTO>().ReverseMap();
            CreateMap<Birthdaylist, UpdateCustomerDTO>();
            CreateMap<Birthdaylist, UpdateCustomerDTO>().ReverseMap();
            CreateMap<Birthdaylist, CreateCustomerDTO>();
            CreateMap<Birthdaylist, CreateCustomerDTO>().ReverseMap();
        }
    }
}
