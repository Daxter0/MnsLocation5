using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MnsLocation5.Areas.Borrower.Controllers
{

    [Area("Borrower")]
    [Authorize(Roles = "Borrower")]


    public class GeneralsViewController : Controller
    {

        private readonly ILogger<GeneralsViewController> _logger;

        public GeneralsViewController(ILogger<GeneralsViewController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserHomePage2()
        {
            return View();
        }
        public IActionResult UserAccountDetail9()
        {
            return View();
        }
        public IActionResult UserGiveBackMaterial12()
        {
            return View();
        }
        public IActionResult UserLocationCart7()
        {
            return View();
        }

        public IActionResult UserLocationDetail11()
        {
            return View();
        }
        public IActionResult UserLocationInformation6()
        {
            return View();
        }
    }
}
