using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DongXu.Target.Web.Controllers
{
    public class ManageLayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}