using System.Diagnostics;
using LVQ_231230881_de01.Models;
using Microsoft.AspNetCore.Mvc;

namespace LVQ_231230881_de01.Controllers
{
    public class lvqHomeController : Controller
    {
        private readonly ILogger<lvqHomeController> _logger;

        public lvqHomeController(ILogger<lvqHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
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
