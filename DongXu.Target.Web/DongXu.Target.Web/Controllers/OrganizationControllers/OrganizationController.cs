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
        public Paged<Role> GetRolesRList(int pageindex=1,int pagesize=6,string name="")
        {
            if(name==null)
            {
                name = "";
            }
            var json = HelperHttpClient.GetAll("get","Organization/GetRolesRList",null);
            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Role>>(json);
            var total = list.Count(m => m.RoleName.Contains(name));
            var maxpage = Math.Ceiling(double.Parse(((float)total / pagesize).ToString()));
            var rolesList = list.Where(m => m.RoleName.Contains(name)).Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
            var rolesPageList = new Paged<Role>
            {
                maxPage = int.Parse(maxpage.ToString()),
                total = total,
                GetList = rolesList
            };
            return rolesPageList;
        }

        public IActionResult PostJob()
        {

            return View();
        }


    }
}