using ShowWatch.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ShowWatch.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ShowController> logger;

        public ShowController(ILogger<ShowController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<Show> Get()
        {
            // create shows and add them to a list
            
            
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Show
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
