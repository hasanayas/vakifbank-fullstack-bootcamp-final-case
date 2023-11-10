using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vk.Base.Response;
using Vk.Operation;
using Vk.Operation.Command;
using Vk.Schema;

namespace Vk.Api.Controllers;

[Route("finalCase/[controller]")]
[ApiController]
public class MailsController:ControllerBase
{
    private IMediator mediator;

    public MailsController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpPost]
    public async Task<ApiResponse> Post([FromBody] MailRequest request)
    {
        var operation = new CreateMailCommand(request);
        var result = await mediator.Send(operation);
        return new ApiResponse();
    }

}
