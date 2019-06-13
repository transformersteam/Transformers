using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DongXu.Target.Web.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// 登录视图
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录方法
        /// </summary>
        /// <returns></returns>
        public int LoginIn()
        {
            var name = Request.Form["name"];
            var pass = Request.Form["pwd"];

            return 1;
        }

    }
}