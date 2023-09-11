using Microsoft.AspNetCore.Mvc;
using NaukaMVC.Models;
using System.Diagnostics;

namespace NaukaMVC.Controllers
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
            var model = new List<Osoba>()
            {
                new Osoba()
                {
                    Imie = "Szymon",
                    Nazwisko = "Pacyno"
                },
                new Osoba()
                {
                    Imie = "Filip",
                    Nazwisko = "Rozbicki"
                },
            };


            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}