using Microsoft.AspNetCore.Mvc;

namespace Equinox.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Simply return the view with navigation links (no need to pass clubs)
            return View();
        }
    }
}
