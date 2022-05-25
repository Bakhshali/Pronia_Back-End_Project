using Microsoft.AspNetCore.Mvc;

namespace BackEnd_1.Task.Areas.ProniaAdmin.Controllers
{

    [Area("ProniaAdmin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
