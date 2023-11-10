using MediatR;
using Vk.Base.Response;
using Vk.Schema;

namespace Vk.Operation;

public record CreateOrderCommand(OrderRequest Model) : IRequest<ApiResponse<OrderResponse>>;
public record UpdateOrderCommand(int Id, OrderUpdatedRequest Model) : IRequest<ApiResponse>;
public record DeleteOrderCommand(int Id) : IRequest<ApiResponse>;
public record GetAllOrderQuery() : IRequest<ApiResponse<List<OrderResponse>>>;
public record GetOrderByIdQuery(int Id) : IRequest<ApiResponse<OrderResponse>>;
public record GetOrderByUserIdQuery(int UserId) : IRequest<ApiResponse<List<OrderResponse>>>;

