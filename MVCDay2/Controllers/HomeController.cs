using Microsoft.AspNetCore.Mvc;

namespace MVCDay2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
