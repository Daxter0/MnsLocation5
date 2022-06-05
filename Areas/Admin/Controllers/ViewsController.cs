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
using System.Linq;
using Microsoft.AspNetCore.Http;

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

            //var admin = await _signInManager.UserManager.GetUserAsync(User);
            //await _signInManager.RefreshSignInAsync(admin);
            var users = _userManager.Users;
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

        public async Task<IActionResult> UpdateUserDetails(string id)
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

            //await _signInManager.RefreshSignInAsync(user);

            //return LocalRedirect("/Identity/Account/Manage/Index");

            return View(user);
        }

        /// <summary>
        /// Sauvegarde les modifications d'un compte effectuées par l'admin
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        
        [HttpPost]
        public async Task<IActionResult> Save(IFormCollection form)
        {
            // Stockage des entrées de l'administrateur

            string userNameInput = form["UserNameInput"];
            string firstNameInput = form["FirstNameInput"];
            string lastNameInput = form["lastNameInput"];
            string adressInput = form["adressInput"];
            string phoneNumberInput = form["phoneNumberInput"];

            var user = await _context.Users.Where(x => x.UserName == userNameInput).FirstOrDefaultAsync(); // Recherche de l'utilisateur qui va être modifié dans la base de donnée
            
            // Modifications de ses propriétés

            user.FirstName = firstNameInput;
            user.LastName = lastNameInput;
            user.Adress = adressInput;
            user.PhoneNumber = phoneNumberInput;

            await _userManager.UpdateAsync(user); 

            var users = _userManager.Users;
            
            return View("AdminAccountIndex", users);
        }
    }
}
