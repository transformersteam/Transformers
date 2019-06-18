using Microsoft.AspNetCore.Mvc;

namespace DongXu.Target.Web.Controllers
{
    public class RunStateController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.id = 1;
            return View();
        }

        /// <summary>
        /// 分部页视图
        /// </summary>
        /// <returns></returns>
        public IActionResult TableResult()
        {
            string str = string.Format("Target/GoalQueryList?goalname=1&goaltype=1&goalleave=1&goalrole=1&goaluser=1&strTime=2019-06-07&endTime=2019-09-07");
            var target = HelperHttpClient.GetAll("get", "WaitRead/GetTargetDetailById?id=", null);
            return View();
        }
    }
}