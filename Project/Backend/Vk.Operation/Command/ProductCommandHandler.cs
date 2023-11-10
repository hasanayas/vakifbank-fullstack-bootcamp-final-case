using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vk.Base.Response;
using Vk.Data.Context;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Schema;

namespace Vk.Operation.Command;

public class ProductCommandHandler :
    IRequestHandler<CreateProductCommand, ApiResponse<ProductResponse>>,
    IRequestHandler<UpdateProductCommand, ApiResponse>,
    IRequestHandler<DeleteProductCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<ProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var mapped = mapper.Map<Product>(request.Model);

        unitOfWork.ProductRepository.Insert(mapped);
        unitOfWork.CompleteTransaction();
        var response = mapper.Map<ProductResponse>(mapped);
        return new ApiResponse<ProductResponse>(response);
    }

    public async Task<ApiResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product entity = await unitOfWork.ProductRepository.GetByIdAsync(request.Id, cancellationToken);
        var mapped = mapper.Map<Product>(request.Model);

        mapped.Id = request.Id;
        mapped.ProductName = request.Model.ProductName != "string" ? request.Model.ProductName : entity.ProductName;
        mapped.ProductImage = request.Model.ProductImage != "string" ? request.Model.ProductImage : entity.ProductImage;
        mapped.ProductQuantity = request.Model.ProductQuantity != default ? request.Model.ProductQuantity : entity.ProductQuantity;
        mapped.ProductPrice = request.Model.ProductPrice != default ? request.Model.ProductPrice : entity.ProductPrice;
        mapped.ProductInformation = request.Model.ProductInformation != "string" ? request.Model.ProductInformation : entity.ProductInformation;

        unitOfWork.ProductRepository.Update(mapped);
        unitOfWork.CompleteTransaction();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        unitOfWork.ProductRepository.Delete(request.Id);
        unitOfWork.CompleteTransaction();
        return new ApiResponse();
    }
}
