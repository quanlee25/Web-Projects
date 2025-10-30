using Microsoft.AspNetCore.Mvc;


namespace Film.Controllers
{
    public class FilmController : Controller
    {
        public ActionResult Index()
        {
            var films = new List<Film.Models.Film>
            {
                new Film.Models.Film { Id = 1, Title = "The Boys", Genre = "Action", Poster = "/images/theboys.jpg", Age = "18+", Rated = 9.6, Booking = "#" },
                new Film.Models.Film { Id = 2, Title = "Dune 2", Genre = "Sci-Fi", Poster = "/images/dune2.jpg", Age = "13+", Rated = 8.5, Booking = "#" }
            };

            return View(films);
        }
    }
}
