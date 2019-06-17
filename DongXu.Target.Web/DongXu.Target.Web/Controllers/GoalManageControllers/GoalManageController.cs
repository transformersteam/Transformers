using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DongXu.Target.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DongXu.Target.Web.Controllers.GoalManageControllers
{
    public class GoalManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 目标管理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult GoalManageShow()
        {
            return View();
        }

        /// <summary>
        /// 目标管理 ztree树
        /// </summary>
        /// <returns></returns>
        public JsonResult GetJsonGoalTree()
        {
            var list = HelperHttpClient.GetAll("get", "GoalManage/GetGoalList", null);
            var goallist = JsonConvert.DeserializeObject<List<Goal>>(list).OrderBy(m=>m.GoalCreateTime);
            return Json(goallist);
        }

        /// <summary>
        /// 目标管理  根据目标id查询目标详情页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetGoalDetailsById(int id)
        {
            var target = HelperHttpClient.GetAll("get", "WaitRead/GetTargetDetailById?id=" + id, null);
            var list = JsonConvert.DeserializeObject<List<TargetDetails>>(target);
            return Json(list);
        }

        /// <summary>
        /// 目标下达页
        /// </summary>
        /// <returns></returns>
        public ActionResult GoalAdd()
        {
            return View();
        }

        /// <summary>
        /// 获取公司列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCommanyList()
        {
            var commany = HelperHttpClient.GetAll("get", "GoalManage/GetCommanyList", null);
            var list = JsonConvert.DeserializeObject<List<Role>>(commany);
            return Json(list);
        }

        /// <summary>
        /// 获取目标类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetGoalTypeList(int id)
        {
            var goaltype= HelperHttpClient.GetAll("get", "GoalManage/GetParentType?id="+id, null);
            var list = JsonConvert.DeserializeObject<List<Goaltype>>(goaltype);
            return Json(list);
        }

        /// <summary>
        /// 获取责任人
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDutyUserList()
        {
            var dutyuser= HelperHttpClient.GetAll("get", "GoalManage/GetDutyUserList", null);
            var list= JsonConvert.DeserializeObject<List<User>>(dutyuser);
            return Json(list);
        }

        /// <summary>
        /// 获取协办人
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDothingUserList()
        {
            var dothinguser= HelperHttpClient.GetAll("get", "GoalManage/GetDothingUserList", null);
            var list= JsonConvert.DeserializeObject<List<User>>(dothinguser);
            return Json(list);
        }
    }
}