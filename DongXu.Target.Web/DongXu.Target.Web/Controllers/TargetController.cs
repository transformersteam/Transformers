using Microsoft.AspNetCore.Mvc;

namespace DongXu.Target.Web.Controllers
{
    public class TargetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}