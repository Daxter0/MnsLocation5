using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MnsLocation5.Data;
using MnsLocation5.Models;
using MnsLocation5.ViewsModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MnsLocation5.Areas.Borrower.Controllers
{

    [Area("Borrower")]
    [Authorize(Roles = "Borrower")]


    public class GeneralsViewController : Controller
    {

        private readonly ILogger<GeneralsViewController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        private readonly SignInManager<User> _signInManager;
        public GeneralsViewController(ILogger<GeneralsViewController> logger, UserManager<User> userManager, AppDbContext context, SignInManager<User> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserHomePage2()
        {
            return View(_context.Types);
        }
        public IActionResult UserAccountDetail9()
        {
            return View();
        }
        public IActionResult UserGiveBackMaterial12()
        {
            return View();
        }
        public async Task<IActionResult> UserLocationCart7Async()
        {
            var model = new UserRentalCartViewModel();
            var user = await _userManager.GetUserAsync(User);
            var cart = _context.RentalCarts.Where(x => x.RentalCartID == user.UserRentalCartRefId).Single();
            
            var list = _context.MaterialRentalCarts.Where(_x => _x.RentalCartID == cart.RentalCartID).ToList();//Get data from associative table
            var listMaterial = new List<Material>();
            foreach (var item in list)
            {
                var materialTest = _context.Materials.Where(x => x.MaterialID == item.MaterialID).FirstOrDefault();
                listMaterial.Add(materialTest);
            }
            model.ChoosenMaterials = listMaterial;
            return View(model);
        }

        public IActionResult UserLocationDetail11()
        {
            return View();
        }
        public IActionResult UserLocationInformation6()
        {
            return View();
        }
        public IActionResult IndexMaterial(int id)
        {
            var model = new CreateMaterialViewModel();
            model.MaterialType = _context.Types.Where(x => x.Id == id).Single();

            var ListMaterial = _context.Materials.Where(x => x.Type.Name == model.MaterialType.Name).ToList();
            model.ListMaterial = ListMaterial.Where(x => x.Statut == "Available").ToList();
            
            return View("IndexMaterial",model);
            
        }

        
        public async Task<IActionResult> AddToRentalCart(int id)
        {

            var material = _context.Materials.FirstOrDefault(x => x.MaterialID == id);
            var user = await _userManager.GetUserAsync(User);
            var cart = _context.RentalCarts.Where(x => x.RentalCartID == user.UserRentalCartRefId).Single();


            cart.ChoosenMaterials.Add(material);
            _context.SaveChanges();
            var indexId = material.TypeRefId;

            return RedirectToAction("IndexMaterial", new {id = indexId});

            
        }

        public async Task<IActionResult> UserRentalCartValidation()
        {
            UserRentalCartViewModel userRentalCartViewModel = new UserRentalCartViewModel();
            var user = await _userManager.GetUserAsync(User);
            var cart = _context.RentalCarts.Where(x => x.RentalCartID == user.UserRentalCartRefId).Single();
            cart.IsValidate = true;
            _context.SaveChanges();


            return View("UserLocationCart7", userRentalCartViewModel);
        }
    }
}
