using Microsoft.AspNetCore.Mvc;
using projekt.Models;
using System.Diagnostics;

namespace projekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Passenger()
        {
            return View(new Passenger);
        }

        public IActionResult Przyloty()
        {
            return View();
        }

        public IActionResult Odloty()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}