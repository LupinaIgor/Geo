using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationGeo111.Data;
using WebApplicationGeo111.Models.Entities.Geo;

namespace WebApplicationGeo111.Controllers.Geo;

public class CityByCountriesController : Controller
    
{
    private readonly ApplicationDbContext _context;
        
    public CityByCountriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(int? CountryId, int? AreaId, int? CityId)
    {
        var countryList = _context.Countries.ToList();
        ViewBag.Countries = new SelectList(countryList, "Id", "Name", CountryId);

        var areaList = CountryId != null
            ? _context.Areas.Where(a => a.CountryId == CountryId).ToList()
            : new List<AreaModel>();

        ViewBag.Areas = new SelectList(areaList, "Id", "Name", AreaId);

        var cityList = AreaId != null
            ? _context.Cities.Where(c => c.AreaId == AreaId).ToList()
            : new List<CityModel>();

        ViewBag.Cities = new SelectList(cityList, "Id", "Name", CityId);

        return View();
    }
}
