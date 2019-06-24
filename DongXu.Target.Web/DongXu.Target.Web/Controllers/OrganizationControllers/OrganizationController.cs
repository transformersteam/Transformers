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
        /// <summary>
        /// 组织管理
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 修改组织
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult UpdateRolesO(Role model)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            var result = HelperHttpClient.GetAll("post","Organization/UpdateRolesO",json);
            return Json(result);
        }

        /// <summary>
        /// 岗位管理页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Role()
        {
            return View();
        }

        /// <summary>
        /// 角色管理页面
        /// </summary>
        /// <returns></returns>
        public IActionResult RoleIndex()
        {
            return View();
        }

        /// <summary>
        /// 查询显示角色
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="name"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 岗位管理
        /// </summary>
        /// <returns></returns>
        public IActionResult PostJob()
        {
            return View();
        }

        /// <summary>
        /// 角色添加
        /// </summary>
        /// <returns></returns>
        public IActionResult AddRoleR()
        {
            return View();
        }

        /// <summary>
        /// 角色修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult UptRolesR(int id) 
        {
            ViewBag.id = id;
            return View();
        }

        /// <summary>
        /// 角色添加 绑定部门下拉
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRolesOList()
        {
            var result = HelperHttpClient.GetAll("get", "Organization/GetRolesOList", null);
            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Role>>(result);
            return list;
        }
        /// <summary>
        /// 显示所有权限
        /// </summary>
        /// <returns></returns>
        public List<Power> GetAllPowerList()
        {
            var result = HelperHttpClient.GetAll("get", "Organization/GetPowerList", null);
            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Power>>(result);
            return list;
        }
        /// <summary>
        /// 权限
        /// </summary>
        /// <param name="Pid"></param>
        /// <returns></returns>
        public List<Power> GetPowerList(int Pid=0)
        {
            var result = HelperHttpClient.GetAll("get", "Organization/GetPowerList", null);
            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Power>>(result);
            list = list.Where(m => m.PowerPid == Pid).ToList();
            return list;
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public JsonResult AddRole(Role role)
        {
            string jsonm = Newtonsoft.Json.JsonConvert.SerializeObject(role);
            var result = HelperHttpClient.GetAll("post", "Organization/AddRole", jsonm);
            return Json(result);
        }

        /// <summary>
        /// 添加角色 权限
        /// </summary>
        /// <param name="rp"></param>
        /// <returns></returns>
        public JsonResult AddRolePower(RolePower rp)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(rp);
            var result = HelperHttpClient.GetAll("post", "Organization/AddRolepower", json);
            return Json(result);
        }

        /// <summary>
        /// 删除角色及权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DeleteRolesR(int id)
        {
            var result = HelperHttpClient.GetAll("post", "Organization/DeleteRolesR", id);
            return Json(result);
        }

        /// <summary>
        /// 反填角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public Role GetRoleById(int roleId)
        {
            var result = HelperHttpClient.GetAll("get", "Organization/GetRoleById?roleId="+ roleId, null);
            Role role = Newtonsoft.Json.JsonConvert.DeserializeObject<Role>(result);
            return role;
        }

        /// <summary>
        /// 反填权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<Rolepower> GetRolepowerById(int roleId)
        {
            var result = HelperHttpClient.GetAll("get","Organization/GetRolepowerById?roleId=" + roleId, null);
            List<Rolepower> rolepower=Newtonsoft.Json.JsonConvert.DeserializeObject<List<Rolepower>>(result);
            return rolepower;
        }
    }
}