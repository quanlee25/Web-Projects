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
    public class Lvq_ChiTietHoaDonController : Controller
    {
        private readonly AppDbContext _context;

        public Lvq_ChiTietHoaDonController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Lvq_ChiTietHoaDon
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ChiTietHoaDons.Include(l => l.Lvq_HoaDon).Include(l => l.Lvq_SanPham);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Lvq_ChiTietHoaDon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvq_ChiTietHoaDon = await _context.ChiTietHoaDons
                .Include(l => l.Lvq_HoaDon)
                .Include(l => l.Lvq_SanPham)
                .FirstOrDefaultAsync(m => m.Lvq_ID == id);
            if (lvq_ChiTietHoaDon == null)
            {
                return NotFound();
            }

            return View(lvq_ChiTietHoaDon);
        }

        // GET: Lvq_ChiTietHoaDon/Create
        public IActionResult Create()
        {
            ViewData["Lvq_HoaDonID"] = new SelectList(_context.HoaDons, "Lvq_ID", "Lvq_ID");
            ViewData["Lvq_SanPhamID"] = new SelectList(_context.SanPhams, "Lvq_ID", "Lvq_ID");
            return View();
        }

        // POST: Lvq_ChiTietHoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Lvq_ID,Lvq_HoaDonID,Lvq_SanPhamID,Lvq_SoLuongMua,Lvq_DonGiaMua,Lvq_ThanhTien,Lvq_TrangThai")] Lvq_ChiTietHoaDon lvq_ChiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lvq_ChiTietHoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Lvq_HoaDonID"] = new SelectList(_context.HoaDons, "Lvq_ID", "Lvq_ID", lvq_ChiTietHoaDon.Lvq_HoaDonID);
            ViewData["Lvq_SanPhamID"] = new SelectList(_context.SanPhams, "Lvq_ID", "Lvq_ID", lvq_ChiTietHoaDon.Lvq_SanPhamID);
            return View(lvq_ChiTietHoaDon);
        }

        // GET: Lvq_ChiTietHoaDon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvq_ChiTietHoaDon = await _context.ChiTietHoaDons.FindAsync(id);
            if (lvq_ChiTietHoaDon == null)
            {
                return NotFound();
            }
            ViewData["Lvq_HoaDonID"] = new SelectList(_context.HoaDons, "Lvq_ID", "Lvq_ID", lvq_ChiTietHoaDon.Lvq_HoaDonID);
            ViewData["Lvq_SanPhamID"] = new SelectList(_context.SanPhams, "Lvq_ID", "Lvq_ID", lvq_ChiTietHoaDon.Lvq_SanPhamID);
            return View(lvq_ChiTietHoaDon);
        }

        // POST: Lvq_ChiTietHoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Lvq_ID,Lvq_HoaDonID,Lvq_SanPhamID,Lvq_SoLuongMua,Lvq_DonGiaMua,Lvq_ThanhTien,Lvq_TrangThai")] Lvq_ChiTietHoaDon lvq_ChiTietHoaDon)
        {
            if (id != lvq_ChiTietHoaDon.Lvq_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lvq_ChiTietHoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Lvq_ChiTietHoaDonExists(lvq_ChiTietHoaDon.Lvq_ID))
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
            ViewData["Lvq_HoaDonID"] = new SelectList(_context.HoaDons, "Lvq_ID", "Lvq_ID", lvq_ChiTietHoaDon.Lvq_HoaDonID);
            ViewData["Lvq_SanPhamID"] = new SelectList(_context.SanPhams, "Lvq_ID", "Lvq_ID", lvq_ChiTietHoaDon.Lvq_SanPhamID);
            return View(lvq_ChiTietHoaDon);
        }

        // GET: Lvq_ChiTietHoaDon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvq_ChiTietHoaDon = await _context.ChiTietHoaDons
                .Include(l => l.Lvq_HoaDon)
                .Include(l => l.Lvq_SanPham)
                .FirstOrDefaultAsync(m => m.Lvq_ID == id);
            if (lvq_ChiTietHoaDon == null)
            {
                return NotFound();
            }

            return View(lvq_ChiTietHoaDon);
        }

        // POST: Lvq_ChiTietHoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lvq_ChiTietHoaDon = await _context.ChiTietHoaDons.FindAsync(id);
            if (lvq_ChiTietHoaDon != null)
            {
                _context.ChiTietHoaDons.Remove(lvq_ChiTietHoaDon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Lvq_ChiTietHoaDonExists(int id)
        {
            return _context.ChiTietHoaDons.Any(e => e.Lvq_ID == id);
        }
    }
}
