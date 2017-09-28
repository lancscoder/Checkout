using AutoMapper;

namespace Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Domain.Basket, Models.Response.Basket>();
            CreateMap<Models.Domain.Item, Models.Response.Item>();
        }
    }
}