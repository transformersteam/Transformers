using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using DongXu.Target.Cache;
using DongXu.Target.Web.Models.Dto;

namespace DongXu.Target.Web.Controllers.OrganizationControllers
{
    
    public class OrganizationController : Controller
    {
        //组织管理
        public IActionResult Index()
        {
            return View();
        }
        
        public JsonResult UpdateRolesO(Role model)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            var result = HelperHttpClient.GetAll("post","Organization/UpdateRolesO",json);
            return Json(result);
        }

        //岗位管理
        public IActionResult Role()
        {
            return View();
        }

        //角色管理
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

        //岗位管理
        public IActionResult PostJob()
        {
            return View();
        }

        //角色添加
        public IActionResult AddRoleR()
        {
            return View();
        }
        //角色修改
        public IActionResult UptRolesR(int id)
        {
            ViewBag.id = id;
            return View();
        }
        //角色添加 绑定部门下拉
        public List<Role> GetRolesOList()
        {
            var result = HelperHttpClient.GetAll("get", "Organization/GetRolesOList", null);
            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Role>>(result);
            return list;
        }

        //显示所有权限
        public List<Power> GetPowerList()
        {
            var result = HelperHttpClient.GetAll("get", "Organization/GetPowerList", null);
            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Power>>(result);
            return list;
        }
        //添加角色
        public JsonResult AddRole(Role model)
        {
            string jsonm = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            var result = HelperHttpClient.GetAll("post", "Organization/AddRole", jsonm);
            return Json(result);
        }
        //添加角色 权限
        public JsonResult AddRolePower(RolePower rp)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(rp);
            var result = HelperHttpClient.GetAll("post", "Organization/AddRolepower", json);
            return Json(result);
        }
        //删除角色及权限
        public JsonResult DeleteRolesR(int id)
        {
            var result = HelperHttpClient.GetAll("post", "Organization/DeleteRolesR", id);
            return Json(result);
        }
        //反填角色
        public Role GetRoleById(int roleId)
        {
            var result = HelperHttpClient.GetAll("get", "Organization/GetRoleById?roleId="+ roleId, null);
            Role role = Newtonsoft.Json.JsonConvert.DeserializeObject<Role>(result);
            return role;
        }
        //反填权限
        public List<Rolepower> GetRolepowerById(int roleId)
        {
            var result = HelperHttpClient.GetAll("get","Organization/GetRolepowerById?roleId=" + roleId, null);
            List<Rolepower> rolepower=Newtonsoft.Json.JsonConvert.DeserializeObject<List<Rolepower>>(result);
            return rolepower;
        }
    }
}