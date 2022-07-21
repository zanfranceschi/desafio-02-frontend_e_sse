using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace src
{
    [Route("[controller]")]
    public class CotacoesController : ControllerBase
    {
        private readonly ILogger<CotacoesController> _logger;
        private readonly Random _random = new Random();

        public CotacoesController(ILogger<CotacoesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task Cotacoes()
        {
            Response.Headers.ContentType = "text/event-stream";

            while (true)
            {
                decimal zan1 = Convert.ToDecimal(_random.Next(20, 30) * (1 + _random.NextDouble()));
                decimal twit4 = Convert.ToDecimal(_random.Next(10, 50) * (1 + _random.NextDouble()));
                decimal lov3 = Convert.ToDecimal(_random.Next(100, 300) * (1 + _random.NextDouble()));

                DateTime timestamp = DateTime.Now;

                var acoes = new []
                {
                    new Acao(timestamp, zan1, "ZAN1"),
                    new Acao(timestamp, twit4, "TWIT4"),
                    new Acao(timestamp, lov3, "LOV3")
                };

                var data = JsonSerializer.Serialize(acoes);

                var valor = _random.NextDouble();
                await Response.WriteAsync($"data: {data}\n\n");
                await Response.Body.FlushAsync();
                Thread.Sleep(_random.Next(1, 8) * 500);
            }
        }

        [HttpGet("/")]
        public ContentResult Index()
        {
            var html = System.IO.File.ReadAllText(@"./frontend.html");
            return base.Content(html, "text/html");
        }
    }
    public record Acao(DateTime timestamp, Decimal valor, string nome);
}