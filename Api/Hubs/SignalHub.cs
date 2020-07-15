using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Hubs
{

    
    public class SignalHub : Hub
    {
        private ILogger<SignalHub> _logger;

        public SignalHub(ILogger<SignalHub> logger)
        {
            _logger = logger;
        }

        
        //public Task SendHello(string hello)
        //{
        //    _logger.LogInformation(hello);
        //    return Task.CompletedTask;
        //}

        //public Task SendMessageToAll(string message)
        //{
        //    _logger.LogInformation($"{nameof(SendMessageToAll)} {message}");
        //    return Clients.All.SendAsync("ReceiveMessage", message);
        //}

        //public Task SendMessage(string user, string message)
        //{
        //    return Clients.All.SendAsync("ReceiveMessage", user, message);
        //}

        //public Task SendMessageToCaller(string message)
        //{
        //    return Clients.Caller.SendAsync("ReceiveMessage", message);
        //}

        //public Task SendMessageToGroup(string message)
        //{
        //    return Clients.Group("SignalR Users").SendAsync("ReceiveMessage", message);
        //}
    }
}
