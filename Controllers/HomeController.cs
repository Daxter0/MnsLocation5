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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserHomePage()
        {
            return View();
        }

        public IActionResult AdminHomePage()
        {
            return View();
        }

        public IActionResult MaterialInventoryList()
        {
            return View();
        }
        public IActionResult MaterialDetail()
        {
            return View();
        }
        public IActionResult UserLocationInformation()
        {
            return View();
        }
        public IActionResult UserLocationCart()
        {
            return View();
        }
        public IActionResult UserAccountDetail()
        {
            return View();
        }
        public IActionResult AdminLocationManagementRequest()
        {
            return View();
        }

        public IActionResult UserLocationDetail()
        {
            return View();
        }
        public IActionResult UserGiveBackMaterial()
        {
            return View();
        }
        public IActionResult AdminValidationMaterialGiveBack()
        {
            return View();
        }
        public IActionResult AdminLocationValidation()
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