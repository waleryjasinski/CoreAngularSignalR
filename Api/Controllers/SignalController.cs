using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Hubs;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignalController : ControllerBase
    {
        private readonly ILogger<SignalController> _logger;
        private readonly IHubContext<SignalHub> _signalHub;

        public SignalController(ILogger<SignalController> logger, IHubContext<SignalHub> signalHub)
        {
            _logger = logger;
            _signalHub = signalHub;
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(SignalItem item)
        {
            _logger.LogInformation($"{nameof(Post)} {item.Message}");

            await _signalHub.Clients.All.SendCoreAsync("ReceiveMessage", new[] { item.Message });

            return StatusCode(StatusCodes.Status200OK, true);
        }




        [HttpGet]
        public ActionResult Get()
        {
            return Ok($"API works ({DateTime.Now:HH:mm:ss})");
        }


    }
}
