using Microsoft.AspNetCore.Mvc;

namespace BuisnessCentral.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }

    }
}
