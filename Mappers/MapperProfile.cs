using AccountShop.Shared.DTOs;
using AutoMapper;

namespace AccountShop.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.CreateMap<ProductInsertRequestDto, Entities.Product>();
        }
    }
}