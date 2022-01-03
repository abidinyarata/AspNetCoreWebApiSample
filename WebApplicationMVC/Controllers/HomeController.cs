using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
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
            // GET 
            // https://localhost:44367/WeatherForecast

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://localhost:44367/WeatherForecast").Result;
            List<WeatherModel> list = new List<WeatherModel>();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                list = JsonSerializer.Deserialize<List<WeatherModel>>(content);
            }

            return View(list);
        }

        public IActionResult Privacy()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://jsonplaceholder.typicode.com/users").Result;
            List<User> users = new List<User>();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                users = JsonSerializer.Deserialize<List<User>>(content);
            }

            return View(users);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
