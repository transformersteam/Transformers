using Microsoft.AspNetCore.Mvc;

namespace DongXu.Target.Web.Controllers
{
    public class TargetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 目标跟踪界面
        /// </summary>
        /// <returns></returns>
        public IActionResult TargetTrack()
        {

            return View();
        }


        public IActionResult Test()
        {
            return View();
        }
    }
}