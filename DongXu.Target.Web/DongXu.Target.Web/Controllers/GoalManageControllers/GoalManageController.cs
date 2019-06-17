using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DongXu.Target.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        /// <summary>
        /// 目标ztree树
        /// </summary>
        /// <returns></returns>
        public JsonResult GetJsonGoalTree()
        {
            var list = HelperHttpClient.GetAll("get", "GoalManage/GetGoalList", null);
            var goallist = JsonConvert.DeserializeObject<List<Goal>>(list).OrderBy(m=>m.GoalCreateTime);
            return Json(goallist);
        }
    }
}