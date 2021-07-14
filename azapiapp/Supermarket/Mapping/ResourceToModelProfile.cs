using AutoMapper;
using azapiapp.Supermarket.Domain.Models;
using azapiapp.Supermarket.Domain.Models.Queries;
using azapiapp.Supermarket.Resources;

namespace azapiapp.Supermarket.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();

            CreateMap<SaveProductResource, Product>()
                .ForMember(src => src.UnitOfMeasurement, opt => opt.MapFrom(src => (EUnitOfMeasurement)src.UnitOfMeasurement));

            CreateMap<ProductsQueryResource, ProductsQuery>();
        }
    }
}