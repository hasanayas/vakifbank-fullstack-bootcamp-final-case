using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vk.Base.Response;
using Vk.Data.Context;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Schema;

namespace Vk.Operation.Query;

public class OrderQueryHandler :
    IRequestHandler<GetAllOrderQuery, ApiResponse<List<OrderResponse>>>,
    IRequestHandler<GetOrderByIdQuery, ApiResponse<OrderResponse>>,
    IRequestHandler<GetOrderByUserIdQuery, ApiResponse<List<OrderResponse>>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public OrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    public async Task<ApiResponse<List<OrderResponse>>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        List<Order> list = unitOfWork.OrderRepository.GetAll("User");
        List<OrderResponse> mapped = mapper.Map<List<OrderResponse>>(list);
        return new ApiResponse<List<OrderResponse>>(mapped);
    }

    public async Task<ApiResponse<OrderResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        Order entity = await unitOfWork.OrderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
        {
            return new ApiResponse<OrderResponse>("Record not found");
        }

        OrderResponse mapped = mapper.Map<OrderResponse>(entity);
        return new ApiResponse<OrderResponse>(mapped);
    }

    public async Task<ApiResponse<List<OrderResponse>>> Handle(GetOrderByUserIdQuery request, CancellationToken cancellationToken)
    {
        List<Order> entity = unitOfWork.OrderRepository.GetUserOrders(request.UserId);
        if (entity is null)
        {
            return new ApiResponse<List<OrderResponse>>("Record not found");
        }

        List<OrderResponse> mapped = mapper.Map<List<OrderResponse>>(entity);
        return new ApiResponse<List<OrderResponse>>(mapped);
    }
}
