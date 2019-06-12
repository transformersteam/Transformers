using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DongXu.Target.Web.Controllers.WaitReadControllers
{
    public class WaitReadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 管理层页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ManagementShow(int id)
        {
            ViewBag.id = id;
            return View();
        }

        /// <summary>
        /// 待办信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetWaitReadList(int id)
        {
            var waitread = HelperHttpClient.GetAll("get", "WaitRead/GetWaitReadList?id=" + id, null);
            var list = JsonConvert.DeserializeObject<List<WaitRead>>(waitread);
            return Json(list);
        }
    }
}