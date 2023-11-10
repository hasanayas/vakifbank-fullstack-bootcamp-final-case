using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vk.Base.Response;
using Vk.Data.Context;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Schema;

namespace Vk.Operation.Query;

public class AddressQueryHandler :
    IRequestHandler<GetAllAddressQuery, ApiResponse<List<AddressResponse>>>,
    IRequestHandler<GetAddressByIdQuery, ApiResponse<AddressResponse>>,
    IRequestHandler<GetAddressByUserIdQuery, ApiResponse<List<AddressResponse>>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public AddressQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<AddressResponse>>> Handle(GetAllAddressQuery request, CancellationToken cancellationToken)
    {
        List<Address> list = unitOfWork.AddressRepository.GetAll("User");
        List<AddressResponse> mapped = mapper.Map<List<AddressResponse>>(list);
        return new ApiResponse<List<AddressResponse>>(mapped);
    }

    public async Task<ApiResponse<AddressResponse>> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {
        Address entity = await unitOfWork.AddressRepository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
        {
            return new ApiResponse<AddressResponse>("Record not found");
        }

        AddressResponse mapped = mapper.Map<AddressResponse>(entity);
        return new ApiResponse<AddressResponse>(mapped);
    }

    public async Task<ApiResponse<List<AddressResponse>>> Handle(GetAddressByUserIdQuery request, CancellationToken cancellationToken)
    {
        List<Address> entity =  unitOfWork.AddressRepository.GetUserAddresses(request.UserId);
        if (entity is null)
        {
            return new ApiResponse<List<AddressResponse>>("Record not found");
        }

        List<AddressResponse> mapped = mapper.Map<List<AddressResponse>>(entity);
        return new ApiResponse<List<AddressResponse>>(mapped);
    }
}
