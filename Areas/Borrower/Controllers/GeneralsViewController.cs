﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MnsLocation5.Data;
using MnsLocation5.Models;
using MnsLocation5.ViewsModel;
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
        public IActionResult UserLocationCart7()
        {
            //var model = new RentalCartViewModel();
            //model.ChoosenMaterial = _context.R
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
        public IActionResult IndexMaterial(MaterialType materialType)
        {
            var model = new CreateMaterialViewModel();
            model.MaterialType = _context.Types.Where(x => x.Id == materialType.Id).Single();
            model.ListMaterial = _context.Materials.Where(x => x.Type.Name == model.MaterialType.Name).ToList();
            return View(model);
        }

        public async Task<IActionResult> AddMaterialInRentalCart(Material material)
        {
            //TODO (possible erreur dans le mcd)
            var user = _userManager.GetUserId(User);
            var model = new RentalCartViewModel();
            model.Cart = _context.RentalCarts.Where(x => x.UserRefId == user).FirstOrDefault();
            if (model.Cart == null)
            {
                RentalCart cart = new RentalCart()
                {
                    UserRefId = user

                };
                _context.Add(cart);
                await _context.SaveChangesAsync();
            }
            model.Cart = _context.RentalCarts.Where(x => x.UserRefId == user).FirstOrDefault();
            model.ChoosenMaterial.Add(material);
            
            _context.Add(model);


            await _context.SaveChangesAsync();
            return View("IndexMaterial");
        }
    }
}
