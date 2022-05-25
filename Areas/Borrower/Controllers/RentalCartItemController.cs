using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MnsLocation5.Areas.Borrower.Data;
using MnsLocation5.Data;
using MnsLocation5.Models;

namespace MnsLocation5.Areas.Borrower.Controllers
{
    [Area("Borrower")]
    public class RentalCartItemController : Controller
    {
        private readonly AppDbContext _context;

        public RentalCartItemController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserArea/UserRentalCartItem
        public async Task<IActionResult> Index()
        {
            return View(await _context.RentalCarts.ToListAsync());
        }

        // GET: UserArea/UserRentalCartItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalCart = await _context.RentalCarts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rentalCart == null)
            {
                return NotFound();
            }

            return View(rentalCart);
        }

        // GET: UserArea/UserRentalCartItem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserArea/UserRentalCartItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID")] RentalCart rentalCart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalCart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentalCart);
        }

        // GET: UserArea/UserRentalCartItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalCart = await _context.RentalCarts.FindAsync(id);
            if (rentalCart == null)
            {
                return NotFound();
            }
            return View(rentalCart);
        }

        // POST: UserArea/UserRentalCartItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID")] RentalCart rentalCart)
        {
            if (id != rentalCart.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalCart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalCartExists(rentalCart.ID))
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
            return View(rentalCart);
        }

        // GET: UserArea/UserRentalCartItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalCart = await _context.RentalCarts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rentalCart == null)
            {
                return NotFound();
            }

            return View(rentalCart);
        }

        // POST: UserArea/UserRentalCartItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalCart = await _context.RentalCarts.FindAsync(id);
            _context.RentalCarts.Remove(rentalCart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalCartExists(int id)
        {
            return _context.RentalCarts.Any(e => e.ID == id);
        }
    }
}
