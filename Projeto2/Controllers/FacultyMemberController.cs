using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Projeto2.Controllers
{
    public class FacultyMemberController : Controller
    {
        private readonly MyDbLibrary _context;

        public FacultyMemberController(MyDbLibrary context)
        {
            _context = context;
        }

        // GET: FacultyMember
        public async Task<IActionResult> Index()
        {
            var myDbLibrary = _context.FacultyMember.Include(f => f.Library);
            return View(await myDbLibrary.ToListAsync());
        }

        // GET: FacultyMember/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FacultyMember == null)
            {
                return NotFound();
            }

            var facultyMember = await _context.FacultyMember
                .Include(f => f.Library)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facultyMember == null)
            {
                return NotFound();
            }

            return View(facultyMember);
        }

        // GET: FacultyMember/Create
        public IActionResult Create()
        {
            ViewData["LibraryId"] = new SelectList(_context.Library, "Id", "Id");
            return View();
        }

        // POST: FacultyMember/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fname,facultycoll,LibraryId,Id,Mname,Maddress,Mno")] FacultyMember facultyMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facultyMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LibraryId"] = new SelectList(_context.Library, "Id", "Id", facultyMember.LibraryId);
            return View(facultyMember);
        }

        // GET: FacultyMember/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FacultyMember == null)
            {
                return NotFound();
            }

            var facultyMember = await _context.FacultyMember.FindAsync(id);
            if (facultyMember == null)
            {
                return NotFound();
            }
            ViewData["LibraryId"] = new SelectList(_context.Library, "Id", "Id", facultyMember.LibraryId);
            return View(facultyMember);
        }

        // POST: FacultyMember/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Fname,facultycoll,LibraryId,Id,Mname,Maddress,Mno")] FacultyMember facultyMember)
        {
            if (id != facultyMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facultyMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultyMemberExists(facultyMember.Id))
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
            ViewData["LibraryId"] = new SelectList(_context.Library, "Id", "Id", facultyMember.LibraryId);
            return View(facultyMember);
        }

        // GET: FacultyMember/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FacultyMember == null)
            {
                return NotFound();
            }

            var facultyMember = await _context.FacultyMember
                .Include(f => f.Library)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facultyMember == null)
            {
                return NotFound();
            }

            return View(facultyMember);
        }

        // POST: FacultyMember/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FacultyMember == null)
            {
                return Problem("Entity set 'MyDbLibrary.FacultyMember'  is null.");
            }
            var facultyMember = await _context.FacultyMember.FindAsync(id);
            if (facultyMember != null)
            {
                _context.FacultyMember.Remove(facultyMember);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacultyMemberExists(int id)
        {
          return (_context.FacultyMember?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
