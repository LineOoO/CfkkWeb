using System.Diagnostics;
using CfkkWeb.Builders;
using CfkkWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CfkkWeb.Controllers
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
            var model = new HomePageModelBuilder().Build();
            return View(model);
        }

        public IActionResult Federation()
        {
            return View();
        }

        public IActionResult Kajukenbo()
        {
            return View();
        }

        public IActionResult Contact()
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
