using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Greeter.DTOs;
using Greeter.Models;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Greeter.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class GreeterController : ControllerBase
    {
        private readonly ILogger<GreeterController> _logger;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public GreeterController(ILogger<GreeterController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public String Get()
        {
            
            var rng = new Random();
            return "Good evening!";
        }
        
        // [HttpPost]
        // public async Task<IActionResult>  GreetingUser([FromBody]GreetingDto owner)
        // {
        //     await GetGreetingForUser(owner);
        //     
        //     _logger.LogInformation("Greeted successfully delivered.");
        //
        //     return Ok();
        //
        // }
        //
        // private async Task GetGreetingForUser(GreetingDto owner)
        // {
        //     var form = await HttpContext.Request.ReadFormAsync();
        //     if (String.IsNullOrWhiteSpace(owner.Name) == false)
        //     {
        //         return await HttpResponseHelper.ValidateAndExtractResult<Greeting>(response, _logger, "");
        //     }
        //     else
        //     {
        //         return BadRequest("error occured");
        //     };
        //     
        // }
        
    }
}