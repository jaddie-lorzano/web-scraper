using Microsoft.AspNetCore.Mvc;

namespace Web_Scraper.Controllers
{
    public class BlogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
