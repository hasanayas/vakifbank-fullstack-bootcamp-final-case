using MediatR;
using Vk.Base.Response;
using Vk.Schema;

namespace Vk.Operation;

public record CreateMailCommand(MailRequest Model) : IRequest<ApiResponse>;
