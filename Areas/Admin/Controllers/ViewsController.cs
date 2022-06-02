using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MnsLocation5.Data;
using MnsLocation5.Models;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using MnsLocation5.Areas.Identity.Pages.Account.Manage;

namespace MnsLocation5.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class ViewsController : Controller
    {
        private readonly ILogger<ViewsController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        private readonly SignInManager<User> _signInManager;

        public ViewsController(ILogger<ViewsController> logger, UserManager<User> userManager, AppDbContext context, SignInManager<User> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;

        }


        public IActionResult AdminHomePage3()
        {
            return View();
        }
        public IActionResult AdminLocationrequestManagement10()
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

        public IActionResult AdminStockAccountManagement8()
        {
            return View();
        }
        public IActionResult AdminAccountIndex()
        {
            var users =_userManager.Users;
            return View(users);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> DeletePersonalData(string id)
        {
            if (id == null)
            {
                NotFound();
            }
            
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                NotFound();
            }
            await _userManager.DeleteAsync(user);
            return RedirectToAction("AdminAccountIndex");
        }

        public async Task UpdateUserDetails(string id)
        {
            IndexModel i = new IndexModel(_userManager, _signInManager);
            await i.Index(id);
            

        }
    }
}
