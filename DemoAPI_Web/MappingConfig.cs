using AutoMapper;
using DemoAPI_Web.Models;
using DemoAPI_Web.Models.Dto;

namespace DemoAPI_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
           

            CreateMap<VillaDTO,VillaCreateDTO>().ReverseMap();
            CreateMap<VillaDTO,VillaUpdateDTO>().ReverseMap();

            CreateMap<VillaNumberDTO, VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumberDTO, VillaNumberUpdateDTO>().ReverseMap();

        }
    }
}
