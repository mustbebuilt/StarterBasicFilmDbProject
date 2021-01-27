using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using BasicFilmDbProject.Models;

namespace BasicFilmDbProject.Controllers
{
    public class HomeController : Controller
    {

        const string SessionName = "_Name";
        const string SessionAge = "_Age";
        const string SessionCart = "_Cart";
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllMovies()
        {
            List<Film> model = _context.Films.ToList();
            return View(model);
        }

 public IActionResult Search(String SearchString, String certType)
        {

            var films = from m in _context.Films

                        select m;

            if (!string.IsNullOrEmpty(SearchString))

            {

                films = films.Where(s => s.FilmTitle.Contains(SearchString));

            }

            if (!string.IsNullOrEmpty(certType))
            {
                films = films.Where(x => x.FilmCertificate == certType);
            }

            var filmCerts = _context.Films.Select(m => m.FilmCertificate).Distinct();


            List<Film> model = films.ToList();
            ViewData["SearchString"] = SearchString;
            ViewData["FilterFilmCert"] = certType;
            ViewData["filmCerts"] = filmCerts.ToList();
            ViewData["filmCertsSelectList"] = new SelectList(filmCerts.ToList());
            return View(model);
        }


        // note uses id because of routing in startup.cs
        [HttpGet]
        public IActionResult FilmDetails(int id)
        {
            //List<Movie> model = _context.Movies.Find(FilmID);
            Film model = _context.Films.Find(id);
            return View(model);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
