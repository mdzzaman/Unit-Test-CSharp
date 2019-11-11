using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Entity;
using WebApi.Interface;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<FruitController> _logger;
        private readonly IJuiceBuilder _juiceBuilder;

        public FruitController(ILogger<FruitController> logger, IJuiceBuilder juiceBuilder)
        {
            _logger = logger;
            _juiceBuilder = juiceBuilder;
        }

        [HttpGet]
        public Juice Get()
        {
            var rng = new Random();
            var order = new Order { NumberOfPeople = 100, NumberOfPeopleNotInterest = 20 };
            _juiceBuilder.CreateNewJuice(order);
            return _juiceBuilder.GetJuice();
        }
    }
}
