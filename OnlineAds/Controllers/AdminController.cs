using Microsoft.AspNetCore.Mvc;
using OnlineAds.Models;
using OnlineAds.Repository;

namespace OnlineAds.Controllers
{
    public class AdminController : Controller
    {
        public readonly DbemarketingContext db;

        public readonly IFileService _fileservice;
        public AdminController(DbemarketingContext context, IFileService fileService)
        {
            db = context;
            _fileservice = fileService;

        }

        //=======================================================ADMIN LOGIN======================================================
        // GET: Admin
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult login(TblAdmin avm)
        {
            TblAdmin ad = db.TblAdmins.Where(x => x.AdUsername == avm.AdUsername && x.AdPassword == avm.AdPassword).SingleOrDefault();
            if (ad != null)
            {
                TempData["ad_id"] = ad.AdId;
                TempData["my_rfk_id"] = ad.AdId.ToString();
                return RedirectToAction("Index", "Users");
            }
            else
            {
                ViewBag.error = "Invalid username or password";

            }

            return View();
        }


        public ActionResult Create()
        {
            if (TempData["ad_id"] == null)
            {
                return RedirectToAction("login");
            }
            return View();
        }

        //=============================================================ADMIN CREATED CATEGORY===========================================
        //[HttpPost]
        //public ActionResult Create(TblCategory cat)
        //{
        //    TblCategory cat2 = new TblCategory();
        //    byte[] fileBytes = System.IO.File.ReadAllBytes(cat.CatImage);
        //    MemoryStream fileStream = new MemoryStream(fileBytes);
        //    cat2.CatImagefile = new FormFile(fileStream,0,fileBytes.Length,cat.CatImage, cat.CatImage);
        //    var c = cat2.CatImagefile;
        //    if (cat2.CatImagefile != null)
        //    {

        //        var fileResult = this._fileservice.SaveImage(c);
        //        if (fileResult.Item1 == 0)
        //        {
        //            TempData["mag"] = "File could not save";
        //            return View("Create");
        //        }
        //        var imageName = fileResult.Item2;
        //        cat2.CatImage = imageName;
        //        cat2.CatName = cat.CatName;
        //        cat2.CatStatus = Convert.ToInt32(TempData["my_rfk_id"]);
        //        db.TblCategories.Add(cat2);
        //        db.SaveChanges();
        //    }

        //    return View("GetCategory");
        //}

        ////=============================================================ALL CATEGORY===================================================
        //public async Task<IActionResult> Index()
        //{
        //    var dbemarketingContext = db.TblCategories.Include(t => t.CatFkAdNavigation);
        //    return View(await dbemarketingContext.ToListAsync());
        //}


        //public ActionResult ViewCategory(int?page)
        //{
        //    int pagesize = 9, pageindex = 1;
        //    pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
        //    var list = db.TblCategories.Where(x => x.CatStatus == 1).OrderByDescending(x => x.CatId).ToList();
        //    IPagedList<TblCategory> stu = list.ToPagedList(pageindex, pagesize);


        //    return View(stu);




        //}

        ////=================================================================CATEGORY DELETE =========================================
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || db.TblCategories == null)
        //    {
        //        return NotFound();
        //    }

        //    var tblCategory = await db.TblCategories
        //        .Include(t => t.CatFkAdNavigation)
        //        .FirstOrDefaultAsync(m => m.CatId == id);
        //    if (tblCategory == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tblCategory);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (db.TblCategories == null)
        //    {
        //        return Problem("Entity set 'DbemarketingContext.TblCategories'  is null.");
        //    }
        //    var tblCategory = await db.TblCategories.FindAsync(id);
        //    if (tblCategory != null)
        //    {
        //        db.TblCategories.Remove(tblCategory);
        //    }

        //    await db.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //// ======================================================CATEGORY EDIT===============================================

        //private bool TblCategoryExists(int id)
        //{
        //    return (db.TblCategories?.Any(e => e.CatId == id)).GetValueOrDefault();
        //}

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || db.TblCategories == null)
        //    {
        //        return NotFound();
        //    }

        //    var tblCategory = await db.TblCategories.FindAsync(id);
        //    if (tblCategory == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["CatFkAd"] = new SelectList(db.TblAdmins, "AdId", "AdId", tblCategory.CatFkAd);
        //    return View(tblCategory);
        //}

        //// POST: Categories/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("CatId,CatName,CatImage,CatFkAd,CatStatus")] TblCategory tblCategory)
        //{
        //    if (id != tblCategory.CatId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            db.Update(tblCategory);
        //            await db.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TblCategoryExists(tblCategory.CatId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CatFkAd"] = new SelectList(db.TblAdmins, "AdId", "AdId", tblCategory.CatFkAd);
        //    return View(tblCategory);
        //}






        //public string uploadimgfile(IFormFile file)
        //{
        //    Random r = new Random();
        //    string path = "-1";
        //    int random = r.Next();
        //    if (file != null && file.Length > 0)
        //    {
        //        string extension = Path.GetExtension(file.FileName);
        //        if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
        //        {
        //            try
        //            {
        //                string filename = Path.GetFileName(file.FileName);
        //               path = Path.Combine("~/Content/upload/", random+filename);


        //                //path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(file.FileName));
        //                //file.SaveAs(path);
        //                //path = "~/Content/upload/" + random + Path.GetFileName(file.FileName);

        //                //    ViewBag.Message = "File uploaded successfully";
        //            }
        //            catch (Exception ex)
        //            {
        //                path = "-1";
        //            }
        //        }
        //        else
        //        {
        //            ViewBag.error=("<script>alert('Only jpg ,jpeg or png formats are acceptable....'); </script>");
        //        }
        //    }

        //    else
        //    {
        //        ViewBag.error = ("<script>alert('Please select a file'); </script>");
        //        path = "-1";
        //    }



        //    return path;
        //}


    }
}
