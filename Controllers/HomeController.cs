using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using MnsLocation5.Models;
using System.Diagnostics;

namespace MnsLocation5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index1()
        {
            return View();
        }

        public IActionResult UserHomePage2()
        {
            return View();
        }

        public IActionResult AdminHomePage3()
        {
            return View();
        }

        public IActionResult MaterialInventoryList4()
        {
            return View();
        }
        public IActionResult MaterialDetail5()
        {
            return View();
        }
        public IActionResult UserLocationInformation6()
        {
            return View();
        }
        public IActionResult UserLocationCart7()
        {
            return View();
        }
        public IActionResult AdminStockAccountManagement8()
        {
            return View();
        }
        public IActionResult UserAccountDetail9()
        {
            return View();
        }
        public IActionResult AdminLocationRequestManagement10()
        {
            return View();
        }

        public IActionResult UserLocationDetail11()
        {
            return View();
        }
        public IActionResult UserGiveBackMaterial12()
        {
            return View();
        }
        public IActionResult AdminValidationMaterialGiveBack13()
        {
            return View();
        }
        public IActionResult AdminLocationValidation14()
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