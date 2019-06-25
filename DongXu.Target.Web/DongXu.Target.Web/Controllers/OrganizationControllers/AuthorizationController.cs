using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using DongXu.Target.Cache;
using DongXu.Target.Web.Models.Dto;
namespace DongXu.Target.Web.Controllers.OrganizationControllers
{
    public class AuthorizationController : Controller
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 分页显示
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Paged<User> GetRoleList(int pageindex = 1, int pagesize = 6, string name = "")
        {
            if (name == null)
            {
                name = "";
            }
            var json = HelperHttpClient.GetAll("get", "Authorization/GetUserList",null);
            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(json);
            var total = list.Count(m => m.UserRealName.Contains(name));
            var maxpage = Math.Ceiling(double.Parse(((float)total / pagesize).ToString()));
            var userList = list.Where(m => m.UserRealName.Contains(name)).Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
            var usersPageList = new Paged<User>
            {
                maxPage = int.Parse(maxpage.ToString()),
                total = total,
                GetList = userList
            };
            return usersPageList;
        }

        /// <summary>
        /// 修改人员页面
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateUser(int id=11)
        {
            ViewBag.id = id;
            return View();
        }

        /// <summary>
        /// 添加人员AddUser
        /// </summary>
        /// <returns></returns>
        public IActionResult AddUser()
        {
            return View();
        }

        /// <summary>
        /// 显示所有人员
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRolesRList()
        {
            var result = HelperHttpClient.GetAll("get","Organization/GetRolesRList", null);
            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Role>>(result);
            return list;
        }

        /// <summary>
        /// 添加人员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult AddUsers(User model)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            var result = HelperHttpClient.GetAll("post", "Authorization/AddUser", json);
            return Json(result);
        }
        
        /// <summary>
        /// 添加人员 角色
        /// </summary>
        /// <param name="rp"></param>
        /// <returns></returns>
        public JsonResult AddUserrole(UserRoleDto rp)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(rp);
            var result = HelperHttpClient.GetAll("post","Authorization/AddUserrole",json);
            return Json(result);
        }

        /// <summary>
        /// 删除人员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DeleteUser(int id)
        {
            var result = HelperHttpClient.GetAll("post", "Authorization/DeleteUser", id);
            return Json(result);
        }

        /// <summary>
        /// 反填角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUserById(int userId)
        {
            var result = HelperHttpClient.GetAll("get", "Authorization/GetUserById?userId=" + userId, null);
            User user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(result);
            return user;
        }

        /// <summary>
        /// 反填权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Userrole> GetUserroleById(int userId)
        {
            var result = HelperHttpClient.GetAll("get", "Authorization/GetUserroleById?userId=" + userId, null);
            List<Userrole> userrole =Newtonsoft.Json.JsonConvert.DeserializeObject<List<Userrole>>(result);
            return userrole;
        }

    }
}