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
public class BasketsController : ControllerBase
{
    private IMediator mediator;

    public BasketsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ApiResponse<List<BasketResponse>>> GetAll()
    {
        var operation = new GetAllBasketQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<BasketResponse>> GetById(int id)
    {
        var operation = new GetBasketByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("UserBaskets/{UserId}")]
    public async Task<ApiResponse<List<BasketResponse>>> GetByUserId(int UserId)
    {
        var operation = new GetBasketByUserIdQuery(UserId);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("OrderBaskets/{OrderId}")]
    public async Task<ApiResponse<List<BasketResponse>>> GetByOrderId(int OrderId)
    {
        var operation = new GetBasketByUserIdQuery(OrderId);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("ProductBaskets/{ProductId}")]
    public async Task<ApiResponse<List<BasketResponse>>> GetByProductId(int ProductId)
    {
        var operation = new GetBasketByUserIdQuery(ProductId);
        var result = await mediator.Send(operation);
        return result;
    }


    [HttpPost]
    public async Task<ApiResponse<BasketResponse>> Post([FromBody] BasketRequest request)
    {
        var operation = new CreateBasketCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<ApiResponse> Put(int id, [FromBody] BasketUpdatedRequest request)
    {
        var operation = new UpdateBasketCommand(id, request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteBasketCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}
