using AutoMapper;
using MediatR;
using Vk.Base.Response;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Schema;


namespace Vk.Operation.Command;

public class BasketCommandHandler :
    IRequestHandler<CreateBasketCommand, ApiResponse<BasketResponse>>,
    IRequestHandler<UpdateBasketCommand, ApiResponse>,
    IRequestHandler<DeleteBasketCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public BasketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<BasketResponse>> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
    {
        var mapped = mapper.Map<Basket>(request.Model);

        unitOfWork.BasketRepository.Insert(mapped);
        unitOfWork.CompleteTransaction();
        var response = mapper.Map<BasketResponse>(mapped);
        return new ApiResponse<BasketResponse>(response);
    }

    public async Task<ApiResponse> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
    {
        Basket entity = await unitOfWork.BasketRepository.GetByIdAsync(request.Id, cancellationToken);
        var mapped = mapper.Map<Basket>(request.Model);

        mapped.Id = request.Id;
        mapped.UserId = request.Model.UserId != default ? request.Model.UserId : entity.UserId;
        mapped.OrderId = request.Model.OrderId != default ? request.Model.OrderId : entity.OrderId;
        mapped.ProductId = request.Model.ProductId != default ? request.Model.ProductId : entity.ProductId;
        mapped.BasketQuantity = request.Model.BasketQuantity != default ? request.Model.BasketQuantity : entity.BasketQuantity;
        mapped.BasketPrice = request.Model.BasketPrice != default ? request.Model.BasketPrice : entity.BasketPrice;
        mapped.BasketStatus = request.Model.BasketStatus;

        unitOfWork.BasketRepository.Update(mapped);
        unitOfWork.CompleteTransaction();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        unitOfWork.BasketRepository.Delete(request.Id);
        unitOfWork.CompleteTransaction();
        return new ApiResponse();
    }
}
