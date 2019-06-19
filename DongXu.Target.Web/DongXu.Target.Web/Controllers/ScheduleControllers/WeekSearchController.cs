using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DongXu.Target.Web.Controllers.ScheduleControllers
{
    public class WeekSearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 周报查询
        /// </summary>
        /// <returns></returns>
        public ActionResult WeekShow()
        {
            return View();
        }
    }
}