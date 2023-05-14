using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineAds.Models;

namespace OnlineAds.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DbemarketingContext _context;

        public ProductsController(DbemarketingContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var dbemarketingContext = _context.TblProducts.Include(t => t.ProFkCatNavigation).Include(t => t.ProFkUserNavigation);
            return View(await dbemarketingContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblProducts == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProducts
                .Include(t => t.ProFkCatNavigation)
                .Include(t => t.ProFkUserNavigation)
                .FirstOrDefaultAsync(m => m.ProId == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["ProFkCat"] = new SelectList(_context.TblCategories, "CatId", "CatId");
            ViewData["ProFkUser"] = new SelectList(_context.TblUsers, "UId", "UId");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProId,ProName,ProImage,ProDes,ProPrice,ProFkCat,ProFkUser")] TblProduct tblProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProFkCat"] = new SelectList(_context.TblCategories, "CatId", "CatId", tblProduct.ProFkCat);
            ViewData["ProFkUser"] = new SelectList(_context.TblUsers, "UId", "UId", tblProduct.ProFkUser);
            return View(tblProduct);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblProducts == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProducts.FindAsync(id);
            if (tblProduct == null)
            {
                return NotFound();
            }
            ViewData["ProFkCat"] = new SelectList(_context.TblCategories, "CatId", "CatId", tblProduct.ProFkCat);
            ViewData["ProFkUser"] = new SelectList(_context.TblUsers, "UId", "UId", tblProduct.ProFkUser);
            return View(tblProduct);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProId,ProName,ProImage,ProDes,ProPrice,ProFkCat,ProFkUser")] TblProduct tblProduct)
        {
            if (id == tblProduct.ProId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProductExists(tblProduct.ProId))
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
            ViewData["ProFkCat"] = new SelectList(_context.TblCategories, "CatId", "CatId", tblProduct.ProFkCat);
            ViewData["ProFkUser"] = new SelectList(_context.TblUsers, "UId", "UId", tblProduct.ProFkUser);
            return View(tblProduct);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblProducts == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProducts
                .Include(t => t.ProFkCatNavigation)
                .Include(t => t.ProFkUserNavigation)
                .FirstOrDefaultAsync(m => m.ProId == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblProducts == null)
            {
                return Problem("Entity set 'DbemarketingContext.TblProducts'  is null.");
            }
            var tblProduct = await _context.TblProducts.FindAsync(id);
            if (tblProduct != null)
            {
                _context.TblProducts.Remove(tblProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProductExists(int id)
        {
          return (_context.TblProducts?.Any(e => e.ProId == id)).GetValueOrDefault();
        }
    }
}
