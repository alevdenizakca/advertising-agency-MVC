using BigSister.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace deneme_bigsister_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult anasayfa()
        {
            return View();
        }

        public IActionResult hakkimizda()
        {
            return View();
        }
        public IActionResult islerimiz()
        {
            return View();
        }
        public IActionResult iletisim() 
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