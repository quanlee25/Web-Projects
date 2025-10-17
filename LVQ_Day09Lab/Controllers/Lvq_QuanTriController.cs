using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LVQ_Day09Lab.Models;
using Lvq_Day09Lab.Models;

namespace LVQ_Day09Lab.Controllers
{
    public class Lvq_QuanTriController : Controller
    {
        private readonly AppDbContext _context;

        public Lvq_QuanTriController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Lvq_QuanTri
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuanTris.ToListAsync());
        }

        // GET: Lvq_QuanTri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvq_QuanTri = await _context.QuanTris
                .FirstOrDefaultAsync(m => m.Lvq_ID == id);
            if (lvq_QuanTri == null)
            {
                return NotFound();
            }

            return View(lvq_QuanTri);
        }

        // GET: Lvq_QuanTri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lvq_QuanTri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Lvq_ID,Lvq_TaiKhoan,Lvq_MatKhau,Lvq_TrangThai")] Lvq_QuanTri lvq_QuanTri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lvq_QuanTri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lvq_QuanTri);
        }

        // GET: Lvq_QuanTri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvq_QuanTri = await _context.QuanTris.FindAsync(id);
            if (lvq_QuanTri == null)
            {
                return NotFound();
            }
            return View(lvq_QuanTri);
        }

        // POST: Lvq_QuanTri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Lvq_ID,Lvq_TaiKhoan,Lvq_MatKhau,Lvq_TrangThai")] Lvq_QuanTri lvq_QuanTri)
        {
            if (id != lvq_QuanTri.Lvq_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lvq_QuanTri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Lvq_QuanTriExists(lvq_QuanTri.Lvq_ID))
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
            return View(lvq_QuanTri);
        }

        // GET: Lvq_QuanTri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvq_QuanTri = await _context.QuanTris
                .FirstOrDefaultAsync(m => m.Lvq_ID == id);
            if (lvq_QuanTri == null)
            {
                return NotFound();
            }

            return View(lvq_QuanTri);
        }

        // POST: Lvq_QuanTri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lvq_QuanTri = await _context.QuanTris.FindAsync(id);
            if (lvq_QuanTri != null)
            {
                _context.QuanTris.Remove(lvq_QuanTri);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Lvq_QuanTriExists(int id)
        {
            return _context.QuanTris.Any(e => e.Lvq_ID == id);
        }
    }
}
