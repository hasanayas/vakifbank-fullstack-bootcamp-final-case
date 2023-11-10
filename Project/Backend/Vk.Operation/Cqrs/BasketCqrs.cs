using MediatR;
using Vk.Base.Response;
using Vk.Schema;


public record CreateBasketCommand(BasketRequest Model) : IRequest<ApiResponse<BasketResponse>>;
public record UpdateBasketCommand(int Id, BasketUpdatedRequest Model) : IRequest<ApiResponse>;
public record DeleteBasketCommand(int Id) : IRequest<ApiResponse>;
public record GetAllBasketQuery() : IRequest<ApiResponse<List<BasketResponse>>>;
public record GetBasketByIdQuery(int Id) : IRequest<ApiResponse<BasketResponse>>;
public record GetBasketByUserIdQuery(int UserId) : IRequest<ApiResponse<List<BasketResponse>>>;
public record GetBasketByOrderIdQuery(int UserId) : IRequest<ApiResponse<List<BasketResponse>>>;
public record GetBasketByProductIdQuery(int UserId) : IRequest<ApiResponse<List<BasketResponse>>>;