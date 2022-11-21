using AutoMapper;
using BuyPhone.Dtos.CartDtos;
using BuyPhone.Dtos.ItemDtos;
using BuyPhone.Dtos.OrderDtos;
using BuyPhone.Dtos.PaymentDtos;
using BuyPhone.Models;

namespace BuyPhone.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Item, ItemCreateDto>().ReverseMap();
            CreateMap<Item, ItemReadDto>().ReverseMap();
            CreateMap<Item, ItemOrderDto>().ReverseMap();
            CreateMap<Cart,CartCreateDto>().ReverseMap();
            CreateMap<Cart, CartReadDto>().ReverseMap();
            CreateMap<Order, OrderReadDto>().ReverseMap();
            CreateMap<Payment, PaymentReadDto>().ReverseMap();
        }
    }
}
