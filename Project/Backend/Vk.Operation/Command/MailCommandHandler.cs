using MediatR;
using System.Net;
using System.Net.Mail;
using Vk.Base.Response;
using Vk.Schema;

namespace Vk.Operation.Command;

public class MailCommandHandler :
    IRequestHandler<CreateMailCommand, ApiResponse>
{
    public MailCommandHandler() { }

    public async Task<ApiResponse> Handle(CreateMailCommand request, CancellationToken cancellationToken)
    {
        MailMessage myMessage = new MailMessage();
        SmtpClient client = new SmtpClient();
        client.Credentials = new System.Net.NetworkCredential("finalcasetest@hotmail.com", "test12345++");
        client.Port = 587;
        client.Host = "smtp-mail.outlook.com";
        client.EnableSsl = true;
        myMessage.To.Add(request.Model.Email);
        myMessage.From = new MailAddress("finalcasetest@hotmail.com");
        myMessage.Body = request.Model.Description;

        client.Send(myMessage);
        return new ApiResponse();
    }

}
