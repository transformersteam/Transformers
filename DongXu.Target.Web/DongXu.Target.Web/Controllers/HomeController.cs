using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DongXu.Target.Web.Models;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using DongXu.Target.Cache;

using DongXu.Target.Web.Models.Dto;

using log4net;

namespace DongXu.Target.Web.Controllers
{
    public class HomeController : BaseController
    {
        private ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(HttpGlobalExceptionFilter));

        [MyActionFilter]
        //[AllowAnonymous]
        public IActionResult Index()
        {
            int userId = LoginInfo.userId;
            RedisHelper.Set("username", LoginInfo.userRealName);
            ViewBag.userId = userId;
            RedisHelper.Set("userid", userId);
            //log.Error("老田测试log4错误日志");
            //log.Error("老蔡测试log4错误日志");
            //log.Error("老牛测试log4错误日志");
            //List<PowerDto> FirstList= GetPowersByPid(userId, 0);
            //ViewBag.FirstList = FirstList;
            //List<PowerDto> SecondList = GetPowersByPid(userId, 0);
            //ViewBag.SecondList = SecondList;
            return View();
        }
        /// <summary>
        /// 绑定左侧下拉
        /// </summary>
        /// <param name="Power_PId"></param>
        /// <returns></returns>
        //public List<PowerDto> GetPowersByPid(int UserId, int Power_PId)
        //{
        //    var result = HelperHttpClient.GetAll("get", "Audit/GetPowersByPid?Power_PId=" + Power_PId + "&UserId=" + UserId, null);
        //    List<PowerDto> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PowerDto>>(result);
        //    return list;
        //}

        public async Task<IActionResult> LoginOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(LoginController.Index), "Login/Index");
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Test()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
