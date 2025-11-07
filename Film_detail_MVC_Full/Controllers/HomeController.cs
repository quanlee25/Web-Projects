using Microsoft.AspNetCore.Mvc;

namespace Film_detail_MVC_Full.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Detail", "Film_detail", new { id = "1" });
        }
    }
}
