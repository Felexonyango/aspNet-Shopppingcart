using AutoMapper;
using ShopOnline.Models.Models;

namespace ShopOnline.API
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {

            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.ProductName, src => src.MapFrom(c => c.Product.Name))
                .ForMember(dest => dest.ProductDescription, src => src.MapFrom(c => c.Product.Description))
                .ForMember(dest => dest.Price, src => src.MapFrom(c => c.Product.Price))
                .ForMember(dest => dest.TotalPrice, src => src.MapFrom(c => c.Product.Price * c.Qty));

            
        }
    }
}
