using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DongXu.Target.Web.Controllers.GoalManageControllers
{
    public class GoalManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 目标管理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult GoalManageShow()
        {
            return View();
        }
    }
}