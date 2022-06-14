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
using MnsLocation5.ViewsModel;
using System.Collections.Generic;

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
            UserRentalCartViewModel userRentalCartViewModel = new UserRentalCartViewModel();

            List<User> userValidateRentalCart =  _context.Users.Where(u => u.RentalCart.IsValidate == true).ToList();

            foreach (User user in userValidateRentalCart)
            {
                userRentalCartViewModel.Users.Add(user);
            }

            return View(userRentalCartViewModel);
        }

        public IActionResult AdminStockAccountManagement8()
        {
            return View();
        }
        public IActionResult AdminAccountIndex()
        {
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
            int rentalCartRefId = user.UserRentalCartRefId;
            var rentalCart = _context.RentalCarts.Where(r => r.RentalCartID == rentalCartRefId).Single();
            _context.RentalCarts.Remove(rentalCart);
            await _userManager.DeleteAsync(user);
            
            await _context.SaveChangesAsync();
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

        public IActionResult UserRentalCartDetail(int id)
        {
            CreateMaterialViewModel rentalViewModel = new CreateMaterialViewModel();

            var rentalCart = _context.RentalCarts.Where(x => x.RentalCartID == id).FirstOrDefault();
            var user = _context.Users.Where(u => u.UserRentalCartRefId == id).FirstOrDefault();

            var list = _context.MaterialRentalCarts.Where(_x => _x.RentalCartID == rentalCart.RentalCartID).ToList();
            var listMaterial = new List<Material>();
            foreach (MaterialRentalCart materialRentalCart in list)
            {
                var material = _context.Materials.Where(x => x.MaterialID == materialRentalCart.MaterialID).FirstOrDefault();
                listMaterial.Add(material);
            }
            
            rentalViewModel.ChoosenMaterials = listMaterial;
            rentalViewModel.RentalCart = rentalCart;
            rentalViewModel.User = user;

            return View("RentalCartDetails", rentalViewModel);
        }

        public async Task<IActionResult> LocationValidation(string id)
        {
            RentValidation rV = new RentValidation();
            var user = _context.Users.Where(u => u.Id == id).FirstOrDefault();
            var rent = _context.Rents.Where(r => r.UserRefId == user.Id).OrderBy(e=>e.ID).LastOrDefault();
            var admin = await _userManager.GetUserAsync(User);
            var rentalCart = _context.RentalCarts.Where(r => r.RentalCartID == user.UserRentalCartRefId).FirstOrDefault();
            var rentValidation = _context.RentValidations.Where(r => r.RentId == rent.ID).FirstOrDefault();

            
            rV.ValidationDate = System.DateTime.Now;
            rV.AdminId = admin.Id;
            rV.RentId = rent.ID;
            rentalCart.IsValidate = false;

            var materialRentalCart = _context.MaterialRentalCarts.Where(r => r.RentalCartID == rentalCart.RentalCartID).ToList();
                
            foreach(MaterialRentalCart materialRentalCart1 in materialRentalCart)
            {
                _context.Remove(materialRentalCart1);
            }

            _context.RentValidations.Add(rV);
            _context.SaveChanges();
            
            return RedirectToAction(nameof(AdminLocationValidation14));
        }

        public IActionResult LocationRefuse()
        {
            return RedirectToAction(nameof(AdminLocationValidation14));
        }
    }
}
