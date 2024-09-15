using Microsoft.AspNetCore.Mvc;

namespace WebApplicationGeo111.Controllers.Geo
{

    public class GeoPageController : Controller
    {
        public IActionResult SomePage()
        {
            return View();
        }
    }

}