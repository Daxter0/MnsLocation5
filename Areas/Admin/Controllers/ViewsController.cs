using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MnsLocation5.Models;
using System.Diagnostics;

namespace MnsLocation5.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ViewsController : Controller
    {
        private readonly ILogger<ViewsController> _logger;

        public ViewsController(ILogger<ViewsController> logger)
        {
            _logger = logger;
        }

        public IActionResult AdminHomePage3()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminLocationValidation14()
        {
            return View();
        }
        public IActionResult AdminStockAccountManagement8()
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
