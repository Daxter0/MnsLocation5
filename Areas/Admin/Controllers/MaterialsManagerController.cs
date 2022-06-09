using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MnsLocation5.Data;
using MnsLocation5.Models;
using MnsLocation5.ViewsModel;


namespace MnsLocation5.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class MaterialsManagerController : Controller
    {
        private readonly AppDbContext _context;

        public MaterialsManagerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminMaterialsManager
        public async Task<IActionResult> Index(string searchName)
        {
            return View(await _context.Materials.Where(x => x.Name.Contains(searchName)|| searchName == null).ToListAsync());
        }

        // GET: Admin/AdminMaterialsManager/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materials
                .FirstOrDefaultAsync(m => m.MaterialID == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // GET: Admin/AdminMaterialsManager/Create
        public IActionResult Create()
        {
            var model = new CreateMaterialViewModel();
            model = ConfigureViewModelListConditions(model);
            model = ConfigureViewModelListTypes(model);
            model.ListStatut = new List<SelectListItem>()
            {
                new SelectListItem{ Text="Disponible", Value ="Available" },
                new SelectListItem{Text="Réservé", Value="Reserved"}
            };
            
            return View(model);
        }

        // POST: Admin/AdminMaterialsManager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create(CreateMaterialViewModel createMaterial, IFormCollection form)
        {
            string materialNameInput = form["MaterialName"];
            string materialQuantityInput = form["NewMaterialQuantity"];
            int materialQuantity = 1;
            bool parse = int.TryParse(materialQuantityInput, out materialQuantity);
            if (ModelState.IsValid)
            {
                for(int i = 0 ; i < materialQuantity ; i++)
                {
                    Material material = new Material() { Name = materialNameInput, TypeRefId = createMaterial.MaterialTypeID, Condition = createMaterial.Material.Condition, Statut=createMaterial.Material.Statut };
                    _context.Add(material);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(createMaterial);
            
        }
      

        // GET: Admin/AdminMaterialsManager/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materials.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            return View(material);
        }

        // POST: Admin/AdminMaterialsManager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Type,Condition,Statut")] Material material)
        {
            if (id != material.MaterialID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(material);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material.MaterialID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(material);
        }

        // GET: Admin/AdminMaterialsManager/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materials
                .FirstOrDefaultAsync(m => m.MaterialID == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: Admin/AdminMaterialsManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var material = await _context.Materials.FindAsync(id);
            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialExists(int id)
        {
            return _context.Materials.Any(e => e.MaterialID == id);
        }

        /// <summary>
        /// Set up the view model listTypes to be rendered properly by the create view
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private CreateMaterialViewModel ConfigureViewModelListTypes(CreateMaterialViewModel model)
        {
            model.ListType = _context.Types.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList();

            return model;
        }

        /// <summary>
        /// Set up the view model listConditions to be rendered properly by the create view
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private CreateMaterialViewModel ConfigureViewModelListConditions(CreateMaterialViewModel model)
        {
            model.ListConditions = new List<SelectListItem>()
            {
                new SelectListItem { Text="Neuf", Value="Neuf"},
                new SelectListItem { Text="Bon état", Value="Bon état"},
                new SelectListItem { Text="Moyen état", Value="Moyen état"},
                new SelectListItem { Text="Mauvais état", Value="Mauvais état"},
                new SelectListItem { Text="Cassé", Value="Cassé"}
            };

            return model;
        }
    }
}
