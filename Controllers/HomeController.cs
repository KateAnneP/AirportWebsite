using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projekt.Data;
using projekt.Models;
using System.Diagnostics;

namespace projekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly projektContext _context;

        public HomeController(ILogger<HomeController> logger, projektContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var projektContext = _context.Flight.Include(f => f.Destination).Include(f => f.Line).Include(f => f.Plane).Include(f => f.Status).Include(f => f.Terminal);
            return View(await projektContext.ToListAsync());
        }

        public IActionResult Passenger()
        {
            return View();
        }

        public IActionResult Przyloty()
        {
            /*var przylotyFlights = _context.Flight
        .Where(f => f.StatusID == 3)
        .ToList();*/

            // Uzyskaj model dla widoku Index, używając tego samego podejścia co w funkcji Index
            var indexModel = _context.Flight.Include(f => f.Destination).Include(f => f.Line).Include(f => f.Plane).Include(f => f.Status).Include(f => f.Terminal).Where(f => f.StatusID == 4 || f.StatusID == 5).ToList();

            // Zwróć widok, przekazując model z funkcji Index
            return View("Index", indexModel);
        }

        public IActionResult Odloty()
        {
            /*var przylotyFlights = _context.Flight
        .Where(f => f.StatusID != 3)
        .ToList();*/

            // Uzyskaj model dla widoku Index, używając tego samego podejścia co w funkcji Index
            var indexModel = _context.Flight.Include(f => f.Destination).Include(f => f.Line).Include(f => f.Plane).Include(f => f.Status).Include(f => f.Terminal).Where(f => f.StatusID != 4 && f.StatusID != 5).ToList();

            // Zwróć widok, przekazując model z funkcji Index
            return View("Index", indexModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

/*
 
 
 */