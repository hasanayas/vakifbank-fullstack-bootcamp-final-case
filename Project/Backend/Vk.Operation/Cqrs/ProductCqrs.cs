using MediatR;
using Vk.Base.Response;
using Vk.Schema;

namespace Vk.Operation;

public record CreateProductCommand(ProductRequest Model) : IRequest<ApiResponse<ProductResponse>>;
public record UpdateProductCommand(int Id, ProductUpdatedRequest Model) : IRequest<ApiResponse>;
public record DeleteProductCommand(int Id) : IRequest<ApiResponse>;
public record GetAllProductQuery() : IRequest<ApiResponse<List<ProductResponse>>>;
public record GetProductByIdQuery(int Id) : IRequest<ApiResponse<ProductResponse>>;
