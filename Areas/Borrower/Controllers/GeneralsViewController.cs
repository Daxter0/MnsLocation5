using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MnsLocation5.Data;
using MnsLocation5.Models;
using MnsLocation5.ViewsModel;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public async Task<IActionResult> UserLocationCart7()
        {
            ViewBag.ErrorMessage = "Veuillez saisir des dates valides";
            var model = new CreateMaterialViewModel();
            var user = await _userManager.GetUserAsync(User);
            var cart = _context.RentalCarts.Where(x => x.RentalCartID == user.UserRentalCartRefId).Single();

            List<Material> materials = await GetUserRentalCartMaterialsAsync();
            model.ListMaterial = materials;
            Quantity(model);
            model.RentalCart = cart;
            model.ChoosenMaterials = materials;
            return View(model);
        }

        public IActionResult UserLocationDetail11()
        {
            return View();
        }
        public IActionResult UserLocationInformation6()
        {
            //var model = new CreateMaterialViewModel();
            //var locationUser = _context.Ren
            return View();
        }
        public async Task<IActionResult> IndexMaterialAsync(int id)
        {
            var model = new CreateMaterialViewModel();
            model.MaterialType = _context.Types.Where(x => x.Id == id).Single();
            await CheckCartUserAsync(model);
            Quantity(model);

            return View("IndexMaterial",model);
            
        }

        
        public async Task<IActionResult> AddToRentalCart(int id, int quantity)
        {
            var material = _context.Materials.FirstOrDefault(x => x.MaterialID == id);
            var user = await _userManager.GetUserAsync(User);
            var cart = _context.RentalCarts.Where(x => x.RentalCartID == user.UserRentalCartRefId).Single();
            //materialInRentalCart = materialInRentalCart.Where(x => x.MaterialID == id).ToList();
            var materials = _context.Materials.Where(x => x.MaterialID != _context.MaterialRentalCarts.Where(m => m.MaterialID == x.MaterialID && cart.RentalCartID == m.RentalCartID).Single().MaterialID && x.Name == material.Name && x.Condition == material.Condition).Take(quantity).ToList();
            

            if(cart.IsValidate == false)
            {
                if(quantity <= materials.Count)
                {
                   
                    foreach (var item in materials)
                    {
                            cart.ChoosenMaterials.Add(item);
                    }
                        
                }                 
                    
                   
                    _context.SaveChanges();               

            }
            else
            {
                // Afficher une popup
            }
            var indexId = material.TypeRefId;

            return RedirectToAction("IndexMaterial", new {id = indexId});


        }
        public IActionResult DeleteInRentalCart(int id)
        {
            var materialInCart = _context.MaterialRentalCarts.Where(x => x.MaterialID == id).Single();
            _context.MaterialRentalCarts.Remove(materialInCart);
            _context.SaveChanges();
            return RedirectToAction("UserLocationCart7");
        }
        public async Task CheckCartUserAsync(CreateMaterialViewModel model)
        {
            var ListMaterial = _context.Materials.Where(x => x.Type.Name == model.MaterialType.Name).ToList();
            var listMaterialToTri = ListMaterial.Where(x => x.Statut == "Available").ToList(); //Keep material who's not reserved
            //Second tri for material who are already in the cart user
            model.ListMaterial = listMaterialToTri; //Copy for not risking to change the list while iterate            
            var user = await _userManager.GetUserAsync(User);
            var materialInUserRentalCart = _context.MaterialRentalCarts.Where(x => x.RentalCartID == user.UserRentalCartRefId).ToList(); // We take all object who are already in the cart user
            var listWhoNotIndex = new List<Material>();
            //Compare which material is already in the cart and in the index
            foreach (var item in listMaterialToTri)
            {
                foreach (var item1 in materialInUserRentalCart)
                {
                    if (item.MaterialID == item1.MaterialID)
                    {
                        listWhoNotIndex.Add(item);
                    }
                }
            }
            model.ListMaterial.RemoveAll(item => listWhoNotIndex.Contains(item)); //remove item from index because it's already in the cart

        }

        [HttpPost]
        public async Task<IActionResult> UserRentalCartValidation(IFormCollection form)
        {
            string startDateInput = form["StartDate"];
            string endDateInput = form["EndDate"];
            string startTimeInput = form["StartTime"];
            string endTimeInput = form["EndTime"];
            DateTime startDate = DateTime.Parse(startDateInput + " " + startTimeInput);
            DateTime endDate = DateTime.Parse(endDateInput + " " + endTimeInput);

            int result = DateTime.Compare(startDate, endDate);


            if (result > 0 || result == 0)
            {
                return RedirectToAction(nameof(UserLocationCart7));
            }
            else
            {
                var user = await _userManager.GetUserAsync(User);
                var cart = _context.RentalCarts.Where(x => x.RentalCartID == user.UserRentalCartRefId).Single();
                cart.IsValidate = true;

                List<Material> materials = await GetUserRentalCartMaterialsAsync();

                materials.ForEach(m => m.Statut = "En attente");
                // Rent Instanciation 

                Rent r = new Rent();

                var rent = _context.Rents.Where(u => u.UserRefId == user.Id).FirstOrDefault();

                r.RentalStart = startDate;
                r.RentalEnd = endDate;
                r.RentRentalCartRefId = user.UserRentalCartRefId;
                r.RentDate = DateTime.Now;
                r.UserRefId = user.Id;

                _context.Rents.Add(r);
                _context.SaveChanges();

                return RedirectToAction(nameof(UserLocationCart7));
            }
        }

        public async Task<IActionResult> UserRentalCartModification()
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = _context.RentalCarts.Where(x => x.RentalCartID == user.UserRentalCartRefId).Single();
            var rent = _context.Rents.Where(r => r.UserRefId == user.Id).OrderBy(e => e.ID).LastOrDefault();

            cart.IsValidate = false;
            _context.Remove(rent);
            _context.SaveChanges();

            return RedirectToAction(nameof(UserHomePage2));

        }
        public void Quantity(CreateMaterialViewModel model)
        {

            foreach (var item in model.ListMaterial.GroupBy(m => new { m.Name, m.Condition }).Select(n => n.First()).ToList())
            {
                List<Material> materials = new List<Material>();

                foreach (var item1 in model.ListMaterial)
                {
                    if (item.Name == item1.Name && item.Condition == item1.Condition)
                    {
                        materials.Add(item1);
                    }

                }
                model.ListOfListMaterials.Add(materials);
            }
        }

        public async Task<List<Material>> GetUserRentalCartMaterialsAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = _context.RentalCarts.Where(x => x.RentalCartID == user.UserRentalCartRefId).Single();
            var list = _context.MaterialRentalCarts.Where(_x => _x.RentalCartID == cart.RentalCartID).ToList();//Get data from associative table
            var listMaterial = new List<Material>();
            foreach (var item in list)
            {
                var materialTest = _context.Materials.Where(x => x.MaterialID == item.MaterialID).FirstOrDefault();
                listMaterial.Add(materialTest);
            }

            return listMaterial;
        }
        public async Task<IActionResult> DeleteItemsAsync(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var material = _context.Materials.Where(x => x.MaterialID == id).Single();
            var cart = _context.RentalCarts.Where(x => x.RentalCartID == user.UserRentalCartRefId).Single();
            IEnumerable<Material> allMaterialInCart = _context.Materials.Where(x => x.MaterialID == _context.MaterialRentalCarts.Where(y => y.MaterialID == x.MaterialID).Single().MaterialID && x.Name == material.Name && x.Condition == material.Condition).ToList();
            //Le LINQ dans le LINQ à l'air de marcher que dans le context donc on fait une foreach imbrique pour parcourir allMaterialInCart
            foreach (var item in allMaterialInCart)
            {
                foreach (var item1 in _context.MaterialRentalCarts.Where(x => x.RentalCartID == cart.RentalCartID))
                {
                    if(item.MaterialID == item1.MaterialID)
                    {
                        _context.MaterialRentalCarts.Remove(item1);

                    }

                }


            }
            _context.SaveChanges();
            return RedirectToAction(nameof(UserLocationCart7));
        }
        //Delete tout le panier, a voir
        public async Task<IActionResult> DeleteAllItemsAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = _context.RentalCarts.Where(x => x.RentalCartID == user.UserRentalCartRefId).Single();
            var allMaterialInRentalCartToDelete1 = _context.MaterialRentalCarts.Where(x => x.MaterialID == _context.Materials.Where(y => y.MaterialID == x.MaterialID).Single().MaterialID && x.RentalCartID == cart.RentalCartID).ToList();
            foreach (var item in allMaterialInRentalCartToDelete1)
            {
                _context.MaterialRentalCarts.Remove(item);


            }
            _context.SaveChanges();
            return RedirectToAction(nameof(UserLocationCart7));
        }
        

    }
}
