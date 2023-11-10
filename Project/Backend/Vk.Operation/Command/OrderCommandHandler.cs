using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vk.Base.Response;
using Vk.Data.Context;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Schema;

namespace Vk.Operation.Command;

public class OrderCommandHandler :
    IRequestHandler<CreateOrderCommand, ApiResponse<OrderResponse>>,
    IRequestHandler<UpdateOrderCommand, ApiResponse>,
    IRequestHandler<DeleteOrderCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public OrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<OrderResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var mapped = mapper.Map<Order>(request.Model);

        unitOfWork.OrderRepository.Insert(mapped);
        unitOfWork.CompleteTransaction();
        var response = mapper.Map<OrderResponse>(mapped);
        return new ApiResponse<OrderResponse>(response);
    }

    public async Task<ApiResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        Order entity = await unitOfWork.OrderRepository.GetByIdAsync(request.Id, cancellationToken);
        var mapped = mapper.Map<Order>(request.Model);

        mapped.Id = request.Id;
        mapped.UserId = request.Model.UserId != default ? request.Model.UserId : entity.UserId;
        mapped.OrderStatus = request.Model.OrderStatus != "string" ? request.Model.OrderStatus : entity.OrderStatus;
        mapped.OrderPaymentMethod = request.Model.OrderPaymentMethod != "string" ? request.Model.OrderPaymentMethod : entity.OrderPaymentMethod;
        mapped.OrderAmount = request.Model.OrderAmount != default ? request.Model.OrderAmount : entity.OrderAmount;

        unitOfWork.OrderRepository.Update(mapped);
        unitOfWork.CompleteTransaction();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        unitOfWork.OrderRepository.Delete(request.Id);
        unitOfWork.CompleteTransaction();
        return new ApiResponse();
    }
}
