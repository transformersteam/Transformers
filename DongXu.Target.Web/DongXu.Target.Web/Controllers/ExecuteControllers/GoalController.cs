using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DongXu.Target.Web.Controllers.ExecuteControllers
{
    public class GoalController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 待办事项显示 方法
        /// </summary>
        /// <returns></returns>
        public IActionResult Show() 
        {
            return View();
        }
        /// <summary>
        /// 待办事项显示 方法
        /// </summary>
        /// <returns></returns>
        public IActionResult List() 
        {
            return View();
        }
    }
}