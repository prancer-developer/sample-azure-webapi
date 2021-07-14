using AutoMapper;
using azapiapp.Supermarket.Domain.Models;
using azapiapp.Supermarket.Domain.Models.Queries;
using azapiapp.Supermarket.Extensions;
using azapiapp.Supermarket.Resources;

namespace azapiapp.Supermarket.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();

            CreateMap<Product, ProductResource>()
                .ForMember(src => src.UnitOfMeasurement,
                           opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));

            CreateMap<QueryResult<Product>, QueryResultResource<ProductResource>>();
        }
    }
}