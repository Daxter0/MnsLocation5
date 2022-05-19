using Microsoft.AspNetCore.Mvc;

namespace MnsLocation5.Areas.Borrower.Controllers
{
    public class GeneralsViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
