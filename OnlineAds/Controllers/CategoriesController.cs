using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineAds.Models;
using OnlineAds.Repository;

namespace OnlineAds.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DbemarketingContext _context;
        private readonly IFileService _fileService;


        public CategoriesController(DbemarketingContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }
        private bool AdminId(int id)
        {
            return (_context.TblAdmins?.Any(e => e.AdId == id)).GetValueOrDefault();
        }
        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var dbemarketingContext = _context.TblCategories.Include(t => t.CatFkAdNavigation);
            return View(await dbemarketingContext.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblCategories == null)
            {
                return NotFound();
            }

            var tblCategory = await _context.TblCategories
                .Include(t => t.CatFkAdNavigation)
                .FirstOrDefaultAsync(m => m.CatId == id);
            if (tblCategory == null)
            {
                return NotFound();
            }

            return View(tblCategory);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            ViewData["CatFkAd"] = new SelectList(_context.TblAdmins, "AdId", "AdId");
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CatId,CatName,CatImage,CatFkAd,CatStatus,CatSubcatname")] TblCategory tblCategory)
        {

            if (ModelState.IsValid)
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(tblCategory.CatImage);
                MemoryStream fileStream = new MemoryStream(fileBytes);
                tblCategory.CatImagefile = new FormFile(fileStream, 0, fileBytes.Length, tblCategory.CatImage, tblCategory.CatImage);
                var c = tblCategory.CatImagefile;
                if (tblCategory.CatImagefile != null)
                {

                    var fileResult = this._fileService.SaveImage(c);
                    if (fileResult.Item1 == 0)
                    {
                        TempData["mag"] = "File could not save";
                        return View("Create");
                    }
                    var imageName = fileResult.Item2;
                    tblCategory.CatImage = imageName;

                }
                else
                {
                    return View("Create");
                }
                _context.Add(tblCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatFkAd"] = new SelectList(_context.TblAdmins, "AdId", "AdId", tblCategory.CatFkAd);
            return View(tblCategory);

            //if (ModelState.IsValid)
            //{

            //    if (tblCategory.CatImage != null)
            //    {
            //        var fileResult = this._fileService.SaveImage(tblCategory.CatImage);
            //        if (fileResult.Item1 == 0)
            //        {
            //            TempData["msg"] = "File Could not found";
            //            return View("Create");
            //        }
            //        var imageName = fileResult.Item2;
            //        tblCategory.CatImage = imageName;

            //    }
            //    else
            //    {
            //        return View("Create");
            //    }
            //    _context.Add(tblCategory);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["CatFkAd"] = new SelectList(_context.TblAdmins, "AdId", "AdId", tblCategory.CatFkAd);
            //return View(tblCategory);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblCategories == null)
            {
                return NotFound();
            }

            var tblCategory = await _context.TblCategories.FindAsync(id);
            if (tblCategory == null)
            {
                return NotFound();
            }
            ViewData["CatFkAd"] = new SelectList(_context.TblAdmins, "AdId", "AdId", tblCategory.CatFkAd);
            return View(tblCategory);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id ,[Bind("CatId,CatName,CatImage,CatFkAd,CatStatus,CatSubcatname")] TblCategory tblCategory)
        {

            if (id == tblCategory.CatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCategoryExists(tblCategory.CatId))
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
            ViewData["CatFkAd"] = new SelectList(_context.TblAdmins, "AdId", "AdId", tblCategory.CatFkAd);
            return View(tblCategory);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblCategories == null)
            {
                return NotFound();
            }

            var tblCategory = await _context.TblCategories
                .Include(t => t.CatFkAdNavigation)
                .FirstOrDefaultAsync(m => m.CatId == id);
            if (tblCategory == null)
            {
                return NotFound();
            }

            return View(tblCategory);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblCategories == null)
            {
                return Problem("Entity set 'DbemarketingContext.TblCategories'  is null.");
            }
            var tblCategory = await _context.TblCategories.FindAsync(id);
            if (tblCategory != null)
            {

                _context.TblCategories.Remove(tblCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCategoryExists(int id)
        {
          return (_context.TblCategories?.Any(e => e.CatId == id)).GetValueOrDefault();
        }
    }
}
