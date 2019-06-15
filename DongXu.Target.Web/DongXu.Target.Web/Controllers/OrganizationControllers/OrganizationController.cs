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
        public IActionResult Role()
        {
            return View();
        }
        public IActionResult RoleIndex()
        {
            return View();
        }
        //查询角色
        public List<Role> GetRolesRList()
        {
            var json = HelperHttpClient.GetAll("get","Organization/GetRolesRList",null);
            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Role>>(json);
            return list;
        }

        public IActionResult PostJob()
        {

            return View();
        }


    }
}