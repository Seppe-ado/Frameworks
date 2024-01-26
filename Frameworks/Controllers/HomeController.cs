using Frameworks.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Frameworks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://restcountries.com/v3.1/name/belgium");
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json") );
            var returned = client.GetAsync(client.BaseAddress).Result;
            if ( returned.IsSuccessStatusCode )
            {
                var data = returned.Content.ReadAsStringAsync().Result;
                
                return View(data);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
