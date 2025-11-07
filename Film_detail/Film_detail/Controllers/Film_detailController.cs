using Microsoft.AspNetCore.Mvc;
using Film_detail.Models;
using System.Text.Json;

namespace Film_detail.Controllers
{
    public class Film_detailController : Controller
    {
        public IActionResult Detail(string id)
        {
            // Đường dẫn tới các file JSON trong wwwroot/json
            var nowShowingPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "phim-dang-chieu.json");
            var upcomingPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "phim-sap-chieu.json");

            // Đọc dữ liệu JSON
            var nowShowing = JsonSerializer.Deserialize<List<FILM_detail>>(System.IO.File.ReadAllText(nowShowingPath));
            var upcoming = JsonSerializer.Deserialize<List<FILM_detail>>(System.IO.File.ReadAllText(upcomingPath));

            // Tìm phim theo ID
            var movie = nowShowing?.FirstOrDefault(m => m.Id == id)
                     ?? upcoming?.FirstOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            // Trả dữ liệu về View
            return View(movie);
        }
    }
}
