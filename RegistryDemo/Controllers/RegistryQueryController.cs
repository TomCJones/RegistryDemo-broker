using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistryDemo.Models;

namespace RegistryDemo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RegistryQueryController : ControllerBase
    {
        private DbContext _dbContext;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<RegistryQueryController> _logger;

        public RegistryQueryController(ILogger<RegistryQueryController> logger, RegistryDemo.Models.SqliteDBContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        [HttpGet]
        public IEnumerable<RegistryQuery> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new RegistryQuery
            {
                Date = DateTime.Now.AddDays(index),
                Name = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
