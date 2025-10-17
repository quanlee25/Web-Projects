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
    public class Lvq_HoaDonController : Controller
    {
        private readonly AppDbContext _context;

        public Lvq_HoaDonController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Lvq_HoaDon
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.HoaDons.Include(l => l.Lvq_KhachHang);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Lvq_HoaDon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvq_HoaDon = await _context.HoaDons
                .Include(l => l.Lvq_KhachHang)
                .FirstOrDefaultAsync(m => m.Lvq_ID == id);
            if (lvq_HoaDon == null)
            {
                return NotFound();
            }

            return View(lvq_HoaDon);
        }

        // GET: Lvq_HoaDon/Create
        public IActionResult Create()
        {
            ViewData["Lvq_KhachHangID"] = new SelectList(_context.KhachHangs, "Lvq_ID", "Lvq_ID");
            return View();
        }

        // POST: Lvq_HoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Lvq_ID,Lvq_MaHoaDon,Lvq_KhachHangID,Lvq_NgayHoaDon,Lvq_NgayNhan,Lvq_HoTenKhachHang,Lvq_Email,Lvq_DienThoai,Lvq_DiaChi,Lvq_TongTriGia,Lvq_TrangThai")] Lvq_HoaDon lvq_HoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lvq_HoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Lvq_KhachHangID"] = new SelectList(_context.KhachHangs, "Lvq_ID", "Lvq_ID", lvq_HoaDon.Lvq_KhachHangID);
            return View(lvq_HoaDon);
        }

        // GET: Lvq_HoaDon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvq_HoaDon = await _context.HoaDons.FindAsync(id);
            if (lvq_HoaDon == null)
            {
                return NotFound();
            }
            ViewData["Lvq_KhachHangID"] = new SelectList(_context.KhachHangs, "Lvq_ID", "Lvq_ID", lvq_HoaDon.Lvq_KhachHangID);
            return View(lvq_HoaDon);
        }

        // POST: Lvq_HoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Lvq_ID,Lvq_MaHoaDon,Lvq_KhachHangID,Lvq_NgayHoaDon,Lvq_NgayNhan,Lvq_HoTenKhachHang,Lvq_Email,Lvq_DienThoai,Lvq_DiaChi,Lvq_TongTriGia,Lvq_TrangThai")] Lvq_HoaDon lvq_HoaDon)
        {
            if (id != lvq_HoaDon.Lvq_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lvq_HoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Lvq_HoaDonExists(lvq_HoaDon.Lvq_ID))
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
            ViewData["Lvq_KhachHangID"] = new SelectList(_context.KhachHangs, "Lvq_ID", "Lvq_ID", lvq_HoaDon.Lvq_KhachHangID);
            return View(lvq_HoaDon);
        }

        // GET: Lvq_HoaDon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvq_HoaDon = await _context.HoaDons
                .Include(l => l.Lvq_KhachHang)
                .FirstOrDefaultAsync(m => m.Lvq_ID == id);
            if (lvq_HoaDon == null)
            {
                return NotFound();
            }

            return View(lvq_HoaDon);
        }

        // POST: Lvq_HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lvq_HoaDon = await _context.HoaDons.FindAsync(id);
            if (lvq_HoaDon != null)
            {
                _context.HoaDons.Remove(lvq_HoaDon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Lvq_HoaDonExists(int id)
        {
            return _context.HoaDons.Any(e => e.Lvq_ID == id);
        }
    }
}
