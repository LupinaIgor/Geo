using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationGeo111.Data;

namespace WebApplicationGeo111.Controllers.Geo
{
    public class SearchGeoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchGeoController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: SeachGeoController
        public async Task<ActionResult> Index(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
                ViewBag.Message = "Введите название города.";
                return View();
            }

            var Ch = await _context
                .Cities
                .Include(city => city.Area)
                .ThenInclude(area => area.Country)
                .ThenInclude(country => country.Capital)
                .Include(city => city.Area)
                .ThenInclude(area => area.RegionCapital)
                .Where(c => c.Name == cityName)
                .FirstOrDefaultAsync();

            if (Ch == null)
            {
                ViewBag.Message = $"Город с именем '{cityName}' не найден.";
                return View();
            }

            return View(Ch); // передача данных в представление
        }

    }
}
