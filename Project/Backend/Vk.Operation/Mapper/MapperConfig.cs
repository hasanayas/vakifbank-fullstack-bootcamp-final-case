using AutoMapper;
using Vk.Data.Domain;
using Vk.Schema;

namespace Vk.Operation.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<ProductRequest, Product>();
        CreateMap<ProductUpdatedRequest, Product>();
        CreateMap<Product, ProductResponse>();

        CreateMap<AddressRequest, Address>();
        CreateMap<AddressUpdatedRequest, Address>();
        CreateMap<Address, AddressResponse>();

        CreateMap<UserRequest, User>();
        CreateMap<UserUpdatedRequest, User>();
        CreateMap<User, UserResponse>();

        CreateMap<OrderRequest, Order>();
        CreateMap<OrderUpdatedRequest, Order>();
        CreateMap<Order, OrderResponse>();

        CreateMap<BasketRequest, Basket>();
        CreateMap<BasketUpdatedRequest, Basket>();
        CreateMap<Basket, BasketResponse>();
    }
}