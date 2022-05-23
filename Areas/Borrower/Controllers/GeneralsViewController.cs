using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MnsLocation5.Areas.Borrower.Controllers
{

    [Area("Borrower")]
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
    }
}
