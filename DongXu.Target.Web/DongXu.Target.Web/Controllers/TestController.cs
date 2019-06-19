using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DongXu.Target.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public int acc()
        {

            HelperHttpClient.GetAll("post", "GoalManage/GoalAdd", "333");

            return 1;
        }

    }
}