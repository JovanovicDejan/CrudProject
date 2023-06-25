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
            Mapper.CreateMap<Brand, BrandDto>();
            Mapper.CreateMap<BrandDto, Brand>();
            Mapper.CreateMap<Distributor, DistributorDto>();
            Mapper.CreateMap<DistributorDto, Distributor>();
            Mapper.CreateMap<Manufacturer, ManufacturerDto>();
            Mapper.CreateMap<ManufacturerDto, Manufacturer>();
        }
    }
}