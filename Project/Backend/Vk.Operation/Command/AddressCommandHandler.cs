using AutoMapper;
using MediatR;
using Vk.Base.Response;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Schema;

namespace Vk.Operation.Command;

public class AddressCommandHandler :
    IRequestHandler<CreateAddressCommand, ApiResponse<AddressResponse>>,
    IRequestHandler<UpdateAddressCommand, ApiResponse>,
    IRequestHandler<DeleteAddressCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public AddressCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<AddressResponse>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var mapped = mapper.Map<Address>(request.Model);

        unitOfWork.AddressRepository.Insert(mapped); 
        unitOfWork.CompleteTransaction();
        var response = mapper.Map<AddressResponse>(mapped);
        return new ApiResponse<AddressResponse>(response);
    }


    public async Task<ApiResponse> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        Address entity = await unitOfWork.AddressRepository.GetByIdAsync(request.Id, cancellationToken);
        var mapped = mapper.Map<Address>(request.Model);

        mapped.Id = request.Id;
        mapped.UserId = request.Model.UserId != default ? request.Model.UserId : entity.UserId;
        mapped.AddressLine1 = request.Model.AddressLine1 != "string" ? request.Model.AddressLine1 : entity.AddressLine1;
        mapped.AddressLine2 = request.Model.AddressLine2 != "string" ? request.Model.AddressLine2 : entity.AddressLine2;
        mapped.City = request.Model.City != "string" ? request.Model.City : entity.City;
        mapped.County = request.Model.County != "string" ? request.Model.County : entity.County;
        mapped.PostalCode = request.Model.PostalCode != default ? request.Model.PostalCode : entity.PostalCode;

        unitOfWork.AddressRepository.Update(mapped);
        unitOfWork.CompleteTransaction();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        unitOfWork.AddressRepository.Delete(request.Id);
        unitOfWork.CompleteTransaction();
        return new ApiResponse();
    }
}
