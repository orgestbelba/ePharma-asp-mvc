using Microsoft.AspNetCore.Mvc;

namespace ePharma_asp_mvc.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
