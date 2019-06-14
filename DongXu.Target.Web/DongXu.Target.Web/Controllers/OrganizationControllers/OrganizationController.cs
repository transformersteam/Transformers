using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DongXu.Target.Web.Controllers.OrganizationControllers
{
    public class OrganizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult UpdateRolesO(Role model)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            var result = HelperHttpClient.GetAll("post", "Organization/UpdateRolesO", json);
            return Json(result);
        }
    }
}