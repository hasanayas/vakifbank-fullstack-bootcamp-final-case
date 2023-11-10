using AutoMapper;
using MediatR;
using Vk.Base.Response;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Schema;

namespace Vk.Operation.Query;

public class BasketQueryHandler :
    IRequestHandler<GetAllBasketQuery, ApiResponse<List<BasketResponse>>>,
    IRequestHandler<GetBasketByIdQuery, ApiResponse<BasketResponse>>,
    IRequestHandler<GetBasketByUserIdQuery, ApiResponse<List<BasketResponse>>>,
    IRequestHandler<GetBasketByOrderIdQuery, ApiResponse<List<BasketResponse>>>,
    IRequestHandler<GetBasketByProductIdQuery, ApiResponse<List<BasketResponse>>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public BasketQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<BasketResponse>>> Handle(GetAllBasketQuery request, CancellationToken cancellationToken)
    {
        List<Basket> list = unitOfWork.BasketRepository.GetAll("User");
        List<BasketResponse> mapped = mapper.Map<List<BasketResponse>>(list);
        return new ApiResponse<List<BasketResponse>>(mapped);
    }

    public async Task<ApiResponse<BasketResponse>> Handle(GetBasketByIdQuery request, CancellationToken cancellationToken)
    {
        Basket entity = await unitOfWork.BasketRepository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
        {
            return new ApiResponse<BasketResponse>("Record not found");
        }

        BasketResponse mapped = mapper.Map<BasketResponse>(entity);
        return new ApiResponse<BasketResponse>(mapped);
    }

    public async Task<ApiResponse<List<BasketResponse>>> Handle(GetBasketByUserIdQuery request, CancellationToken cancellationToken)
    {
        List<Basket> entity = unitOfWork.BasketRepository.GetUserBaskets(request.UserId);
        if (entity is null)
        {
            return new ApiResponse<List<BasketResponse>>("Record not found");
        }

        List<BasketResponse> mapped = mapper.Map<List<BasketResponse>>(entity);
        return new ApiResponse<List<BasketResponse>>(mapped);
    }

    public async Task<ApiResponse<List<BasketResponse>>> Handle(GetBasketByOrderIdQuery request, CancellationToken cancellationToken)
    {
        List<Basket> entity = unitOfWork.BasketRepository.GetUserBaskets(request.UserId);
        if (entity is null)
        {
            return new ApiResponse<List<BasketResponse>>("Record not found");
        }

        List<BasketResponse> mapped = mapper.Map<List<BasketResponse>>(entity);
        return new ApiResponse<List<BasketResponse>>(mapped);
    }

    public async Task<ApiResponse<List<BasketResponse>>> Handle(GetBasketByProductIdQuery request, CancellationToken cancellationToken)
    {
        List<Basket> entity = unitOfWork.BasketRepository.GetUserBaskets(request.UserId);
        if (entity is null)
        {
            return new ApiResponse<List<BasketResponse>>("Record not found");
        }

        List<BasketResponse> mapped = mapper.Map<List<BasketResponse>>(entity);
        return new ApiResponse<List<BasketResponse>>(mapped);
    }
}
