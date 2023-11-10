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
public class AddressesController : ControllerBase
{
    private IMediator mediator;

    public AddressesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ApiResponse<List<AddressResponse>>> GetAll()
    {
        var operation = new GetAllAddressQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<AddressResponse>> GetById(int id)
    {
        var operation = new GetAddressByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("UserAddress/{UserId}")]
    public async Task<ApiResponse<List<AddressResponse>>> GetByUserId(int UserId)
    {
        var operation = new GetAddressByUserIdQuery(UserId);
        var result = await mediator.Send(operation);
        return result;
    }


    [HttpPost]
    public async Task<ApiResponse<AddressResponse>> Post([FromBody] AddressRequest request)
    {
        var operation = new CreateAddressCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<ApiResponse> Put(int id, [FromBody] AddressUpdatedRequest request)
    {
        var operation = new UpdateAddressCommand(id, request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteAddressCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}
