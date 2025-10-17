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
    public class Lvq_SanPhamController : Controller
    {
        private readonly AppDbContext _context;

        public Lvq_SanPhamController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Lvq_SanPham
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SanPhams.Include(l => l.Lvq_LoaiSanPham);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Lvq_SanPham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvq_SanPham = await _context.SanPhams
                .Include(l => l.Lvq_LoaiSanPham)
                .FirstOrDefaultAsync(m => m.Lvq_ID == id);
            if (lvq_SanPham == null)
            {
                return NotFound();
            }

            return View(lvq_SanPham);
        }

        // GET: Lvq_SanPham/Create
        public IActionResult Create()
        {
            ViewData["Lvq_LoaiSanPhamID"] = new SelectList(_context.LoaiSanPhams, "Lvq_ID", "Lvq_ID");
            return View();
        }

        // POST: Lvq_SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Lvq_ID,Lvq_MaSanPham,Lvq_TenSanPham,Lvq_HinhAnh,Lvq_SoLuong,Lvq_DonGia,Lvq_TrangThai,Lvq_LoaiSanPhamID")] Lvq_SanPham lvq_SanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lvq_SanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Lvq_LoaiSanPhamID"] = new SelectList(_context.LoaiSanPhams, "Lvq_ID", "Lvq_ID", lvq_SanPham.Lvq_LoaiSanPhamID);
            return View(lvq_SanPham);
        }

        // GET: Lvq_SanPham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvq_SanPham = await _context.SanPhams.FindAsync(id);
            if (lvq_SanPham == null)
            {
                return NotFound();
            }
            ViewData["Lvq_LoaiSanPhamID"] = new SelectList(_context.LoaiSanPhams, "Lvq_ID", "Lvq_ID", lvq_SanPham.Lvq_LoaiSanPhamID);
            return View(lvq_SanPham);
        }

        // POST: Lvq_SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Lvq_ID,Lvq_MaSanPham,Lvq_TenSanPham,Lvq_HinhAnh,Lvq_SoLuong,Lvq_DonGia,Lvq_TrangThai,Lvq_LoaiSanPhamID")] Lvq_SanPham lvq_SanPham)
        {
            if (id != lvq_SanPham.Lvq_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lvq_SanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Lvq_SanPhamExists(lvq_SanPham.Lvq_ID))
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
            ViewData["Lvq_LoaiSanPhamID"] = new SelectList(_context.LoaiSanPhams, "Lvq_ID", "Lvq_ID", lvq_SanPham.Lvq_LoaiSanPhamID);
            return View(lvq_SanPham);
        }

        // GET: Lvq_SanPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvq_SanPham = await _context.SanPhams
                .Include(l => l.Lvq_LoaiSanPham)
                .FirstOrDefaultAsync(m => m.Lvq_ID == id);
            if (lvq_SanPham == null)
            {
                return NotFound();
            }

            return View(lvq_SanPham);
        }

        // POST: Lvq_SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lvq_SanPham = await _context.SanPhams.FindAsync(id);
            if (lvq_SanPham != null)
            {
                _context.SanPhams.Remove(lvq_SanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Lvq_SanPhamExists(int id)
        {
            return _context.SanPhams.Any(e => e.Lvq_ID == id);
        }
    }
}
