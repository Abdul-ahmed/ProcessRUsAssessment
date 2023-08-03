using AutoMapper;
using ProcessRUsAssessment.Models;
using ProcessRUsAssessment.RquestResponseDTOs;
using System.Diagnostics.Metrics;

namespace ProcessRUsAssessment.AutoMapperConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, CreateUser>().ReverseMap();
            CreateMap<User, LoginUser>().ReverseMap();
        }
    }
}
