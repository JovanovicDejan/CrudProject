using AutoMapper;
using ProdavnicaPiva.Dtos;
using ProdavnicaPiva.Models;

namespace ProdavnicaPiva.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Beer, BeerDto>();
            Mapper.CreateMap<BeerDto, Beer>();
        }
    }
}