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
    public class Lvq_LoaiSanPhamController : Controller
    {
        private readonly AppDbContext _context;

        public Lvq_LoaiSanPhamController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Lvq_LoaiSanPham
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiSanPhams.ToListAsync());
        }

        // GET: Lvq_LoaiSanPham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvq_LoaiSanPham = await _context.LoaiSanPhams
                .FirstOrDefaultAsync(m => m.Lvq_ID == id);
            if (lvq_LoaiSanPham == null)
            {
                return NotFound();
            }

            return View(lvq_LoaiSanPham);
        }

        // GET: Lvq_LoaiSanPham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lvq_LoaiSanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Lvq_ID,Lvq_MaLoai,Lvq_TenLoai,Lvq_TrangThai")] Lvq_LoaiSanPham lvq_LoaiSanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lvq_LoaiSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lvq_LoaiSanPham);
        }

        // GET: Lvq_LoaiSanPham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvq_LoaiSanPham = await _context.LoaiSanPhams.FindAsync(id);
            if (lvq_LoaiSanPham == null)
            {
                return NotFound();
            }
            return View(lvq_LoaiSanPham);
        }

        // POST: Lvq_LoaiSanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Lvq_ID,Lvq_MaLoai,Lvq_TenLoai,Lvq_TrangThai")] Lvq_LoaiSanPham lvq_LoaiSanPham)
        {
            if (id != lvq_LoaiSanPham.Lvq_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lvq_LoaiSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Lvq_LoaiSanPhamExists(lvq_LoaiSanPham.Lvq_ID))
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
            return View(lvq_LoaiSanPham);
        }

        // GET: Lvq_LoaiSanPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvq_LoaiSanPham = await _context.LoaiSanPhams
                .FirstOrDefaultAsync(m => m.Lvq_ID == id);
            if (lvq_LoaiSanPham == null)
            {
                return NotFound();
            }

            return View(lvq_LoaiSanPham);
        }

        // POST: Lvq_LoaiSanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lvq_LoaiSanPham = await _context.LoaiSanPhams.FindAsync(id);
            if (lvq_LoaiSanPham != null)
            {
                _context.LoaiSanPhams.Remove(lvq_LoaiSanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Lvq_LoaiSanPhamExists(int id)
        {
            return _context.LoaiSanPhams.Any(e => e.Lvq_ID == id);
        }
    }
}
