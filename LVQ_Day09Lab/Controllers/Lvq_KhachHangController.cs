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
    public class Lvq_KhachHangController : Controller
    {
        private readonly AppDbContext _context;

        public Lvq_KhachHangController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Lvq_KhachHang
        public async Task<IActionResult> Index()
        {
            return View(await _context.KhachHangs.ToListAsync());
        }

        // GET: Lvq_KhachHang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvq_KhachHang = await _context.KhachHangs
                .FirstOrDefaultAsync(m => m.Lvq_ID == id);
            if (lvq_KhachHang == null)
            {
                return NotFound();
            }

            return View(lvq_KhachHang);
        }

        // GET: Lvq_KhachHang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lvq_KhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Lvq_ID,Lvq_MaKhachHang,Lvq_HoTenKhachHang,Lvq_Email,Lvq_MatKhau,Lvq_DienThoai,Lvq_DiaChi,Lvq_NgayDangKy,Lvq_TrangThai")] Lvq_KhachHang lvq_KhachHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lvq_KhachHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lvq_KhachHang);
        }

        // GET: Lvq_KhachHang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvq_KhachHang = await _context.KhachHangs.FindAsync(id);
            if (lvq_KhachHang == null)
            {
                return NotFound();
            }
            return View(lvq_KhachHang);
        }

        // POST: Lvq_KhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Lvq_ID,Lvq_MaKhachHang,Lvq_HoTenKhachHang,Lvq_Email,Lvq_MatKhau,Lvq_DienThoai,Lvq_DiaChi,Lvq_NgayDangKy,Lvq_TrangThai")] Lvq_KhachHang lvq_KhachHang)
        {
            if (id != lvq_KhachHang.Lvq_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lvq_KhachHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Lvq_KhachHangExists(lvq_KhachHang.Lvq_ID))
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
            return View(lvq_KhachHang);
        }

        // GET: Lvq_KhachHang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvq_KhachHang = await _context.KhachHangs
                .FirstOrDefaultAsync(m => m.Lvq_ID == id);
            if (lvq_KhachHang == null)
            {
                return NotFound();
            }

            return View(lvq_KhachHang);
        }

        // POST: Lvq_KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lvq_KhachHang = await _context.KhachHangs.FindAsync(id);
            if (lvq_KhachHang != null)
            {
                _context.KhachHangs.Remove(lvq_KhachHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Lvq_KhachHangExists(int id)
        {
            return _context.KhachHangs.Any(e => e.Lvq_ID == id);
        }
    }
}
