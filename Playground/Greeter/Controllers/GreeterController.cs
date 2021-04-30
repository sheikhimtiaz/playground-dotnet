using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Confluent.Kafka;
using Greeter.DTOs;
using Greeter.Constants;
using Greeter.Models;
using Greeter.Producers;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Greeter.Controllers
{
    [ApiController]
    [Route("/[controller]")]
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

        // [HttpGet]
        // public String Get()
        // {
        //     
        //     var rng = new Random();
        //     return "Good evening!";
        // }
        
        // [HttpPost]
        // public IEnumerable<WeatherForecast> GetPost()
        // {
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //         {
        //             Date = DateTime.Now.AddDays(index),
        //             TemperatureC = rng.Next(-20, 55),
        //             Summary = Summaries[rng.Next(Summaries.Length)]
        //         })
        //         .ToArray();
        // }
        
        [HttpPost]
        public IActionResult GreetingUser([FromBody]GreetingDto owner)
        {
            KafkaProducer sample = new KafkaProducer();
            return Created(string.Empty, sample.SendToKafka(Constants.Constants.TOPIC, GetGreetingForUser(owner)));
            // return Created(string.Empty, GetGreetingForUser(owner));
        
        }
        
        private string GetGreetingForUser(GreetingDto owner)
        {
            string message = "Name is required ... ";
            if (String.IsNullOrWhiteSpace(owner.Name) == true)
            {
                Console.WriteLine("Name is required ... ");
            }
            else
            {
                Console.WriteLine("hello there ... General {0}", owner.Name);
                message = "hello there ... General " + owner.Name;
            };
            return message;
        }
        
        // [HttpPost]
        // public IActionResult Post([FromQuery] string message)
        // {
        //     KafkaProducer sample = new KafkaProducer();
        //     return Created(string.Empty, sample.SendToKafka(topic, message));
        // }
    }
}