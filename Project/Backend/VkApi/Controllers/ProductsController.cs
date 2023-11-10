using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Vk.Base.Response;
using Vk.Operation;
using Vk.Schema;

namespace Vk.Api.Controllers;

[Route("finalCase/[controller]")]
[ApiController]
public class ProductsController:ControllerBase
{
    private IMediator mediator;

    public ProductsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ApiResponse<List<ProductResponse>>> GetAll()
    {
        var operation = new GetAllProductQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<ProductResponse>> GetById(int id)
    {
        var operation = new GetProductByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    public async Task<ApiResponse<ProductResponse>> Post([FromBody] ProductRequest request)
    {
        var operation = new CreateProductCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<ApiResponse> Put(int id, [FromBody] ProductUpdatedRequest request)
    {
        var operation = new UpdateProductCommand(id, request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteProductCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}
