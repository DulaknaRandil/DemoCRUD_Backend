using AutoMapper;
using ProductAPI.Dto;
using ProductAPI.Model;

namespace ProductAPI.Mapping
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile() {

            CreateMap<Product, ProductDto>().ReverseMap();
        
        }
    }
}
