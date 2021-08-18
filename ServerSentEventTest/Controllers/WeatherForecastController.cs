using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSentEventTest.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        public async Task SSE()
        {
            Response.ContentType = "text/event-stream; charset=UTF-8";
            StreamWriter sw;
            await using ((sw = new StreamWriter(Response.Body)).ConfigureAwait(false))
            {
                foreach (var item in Enumerable.Range(0, 100))
                {
                    await sw.WriteLineAsync($@"id: {Guid.NewGuid()}").ConfigureAwait(false);
                    await sw.WriteLineAsync($@"event: post").ConfigureAwait(false);
                    await sw.WriteLineAsync($@"data: {item}").ConfigureAwait(false);
                    await sw.FlushAsync().ConfigureAwait(false);
                    await Task.Delay(1000);
                }
            }
        }
    }
}