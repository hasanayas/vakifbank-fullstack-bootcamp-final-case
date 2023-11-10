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
public class OrdersController : ControllerBase
{
    private IMediator mediator;

    public OrdersController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ApiResponse<List<OrderResponse>>> GetAll()
    {
        var operation = new GetAllOrderQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<OrderResponse>> GetById(int id)
    {
        var operation = new GetOrderByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("UserOrders/{UserId}")]
    public async Task<ApiResponse<List<OrderResponse>>> GetByUserId(int UserId)
    {
        var operation = new GetOrderByUserIdQuery(UserId);
        var result = await mediator.Send(operation);
        return result;
    }


    [HttpPost]

    public async Task<ApiResponse<OrderResponse>> Post([FromBody] OrderRequest request)
    {
        var operation = new CreateOrderCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<ApiResponse> Put(int id, [FromBody] OrderUpdatedRequest request)
    {
        var operation = new UpdateOrderCommand(id, request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteOrderCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}
