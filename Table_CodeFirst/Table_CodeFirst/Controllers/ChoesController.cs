using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Table_CodeFirst.Models;
using System.Threading.Tasks;
using System.Linq;

namespace Table_CodeFirst.Controllers
{
    public class ChoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Choes
        public async Task<IActionResult> Index()
        {
            var choList = await _context.Chos.ToListAsync();
            return View(choList);
        }

        // GET: Choes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var cho = await _context.Chos.FirstOrDefaultAsync(m => m.Id == id);
            if (cho == null)
                return NotFound();

            return View(cho);
        }

        // GET: Choes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Choes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ten,Giong")] Cho cho)
        {
            if (ModelState.IsValid)
            {
                _context.Chos.Add(cho); // ✅ Thêm mới
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cho);
        }

        // GET: Choes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var cho = await _context.Chos.FindAsync(id);
            if (cho == null)
                return NotFound();

            return View(cho);
        }

        // POST: Choes/Edit/5
        // POST: Choes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ten,Giong")] Cho cho)
        {
            if (id != cho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cho); // ✅ sửa lại dòng này
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChoExists(cho.Id))
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
            return View(cho);
        }


        // GET: Choes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var cho = await _context.Chos.FirstOrDefaultAsync(m => m.Id == id);
            if (cho == null)
                return NotFound();

            return View(cho);
        }

        // POST: Choes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cho = await _context.Chos.FindAsync(id);
            if (cho != null)
            {
                _context.Chos.Remove(cho);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ChoExists(int id)
        {
            return _context.Chos.Any(e => e.Id == id);
        }
    }
}
