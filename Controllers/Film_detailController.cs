using Microsoft.AspNetCore.Mvc;
using Film_detail.Models;
using System.Text.Json;

namespace Film_detail.Controllers
{
    public class Film_detailController : Controller
    {
        public IActionResult Detail(string id)
        {
            var nowShowingPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "phim-dang-chieu.json");
            var upcomingPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "phim-sap-chieu.json");

            if (!System.IO.File.Exists(nowShowingPath) && !System.IO.File.Exists(upcomingPath))
            {
                return Problem("JSON data files not found in wwwroot/json. Please ensure phim-dang-chieu.json and phim-sap-chieu.json exist.");
            }

            List<FILM_detail>? nowShowing = null;
            List<FILM_detail>? upcoming = null;

            if (System.IO.File.Exists(nowShowingPath))
                nowShowing = JsonSerializer.Deserialize<List<FILM_detail>>(System.IO.File.ReadAllText(nowShowingPath));

            if (System.IO.File.Exists(upcomingPath))
                upcoming = JsonSerializer.Deserialize<List<FILM_detail>>(System.IO.File.ReadAllText(upcomingPath));

            var movie = nowShowing?.FirstOrDefault(m => m.Id == id)
                      ?? upcoming?.FirstOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return View(movie);
        }
    }
}
