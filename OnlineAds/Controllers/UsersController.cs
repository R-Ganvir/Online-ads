﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineAds.Models;

namespace OnlineAds.Controllers
{
    public class UsersController : Controller
    {
        private readonly DbemarketingContext _context;

        public UsersController(DbemarketingContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
              return _context.TblUsers != null ? 
                          View(await _context.TblUsers.ToListAsync()) :
                          Problem("Entity set 'DbemarketingContext.TblUsers'  is null.");
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblUsers == null)
            {
                return NotFound();
            }

            var tblUser = await _context.TblUsers
                .FirstOrDefaultAsync(m => m.UId == id);
            if (tblUser == null)
            {
                return NotFound();
            }

            return View(tblUser);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UId,UPassword,UName,UDateofbirth,UGender,UCity,UState,UEmail,UImage,UContact")] TblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblUser);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblUsers == null)
            {
                return NotFound();
            }

            var tblUser = await _context.TblUsers.FindAsync(id);
            if (tblUser == null)
            {
                return NotFound();
            }
            return View(tblUser);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UId,UPassword,UName,UDateofbirth,UGender,UCity,UState,UEmail,UImage,UContact")] TblUser tblUser)
        {
            if (id != tblUser.UId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUserExists(tblUser.UId))
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
            return View(tblUser);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblUsers == null)
            {
                return NotFound();
            }

            var tblUser = await _context.TblUsers
                .FirstOrDefaultAsync(m => m.UId == id);
            if (tblUser == null)
            {
                return NotFound();
            }

            return View(tblUser);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblUsers == null)
            {
                return Problem("Entity set 'DbemarketingContext.TblUsers'  is null.");
            }
            var tblUser = await _context.TblUsers.FindAsync(id);
            if (tblUser != null)
            {
                _context.TblUsers.Remove(tblUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblUserExists(int id)
        {
          return (_context.TblUsers?.Any(e => e.UId == id)).GetValueOrDefault();
        }
    }
}
