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
        public IActionResult Index()
        {
            ViewBag.name = LoginInfo.userRealName;
            int userId = LoginInfo.userId;
            RedisHelper.Set("username", LoginInfo.userRealName);
            ViewBag.userId = userId;
            RedisHelper.Set("userid", userId);

            ViewBag.press = RedisHelper.Get<LoginModel>(LoginInfo.userName).PowerList;

            return View();
        }
        [MyActionFilter]
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

        [AllowAnonymous]
        [Route("Home/Error/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            return View();
        }

    }
}
