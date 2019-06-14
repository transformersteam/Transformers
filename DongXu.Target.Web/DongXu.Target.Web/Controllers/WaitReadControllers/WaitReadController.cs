﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DongXu.Target.Web.Controllers.WaitReadControllers
{
    public class WaitReadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 管理层页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ManagementShow(int id)
        {
            ViewBag.id = id;
            return View();
        }

        /// <summary>
        /// 待办信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetWaitReadList(int pageIndex = 1, int pageSize = 3, int id = 0)
        {
            var waitread = HelperHttpClient.GetAll("get", "WaitRead/GetWaitReadList?id=" + id, null);
            var list = JsonConvert.DeserializeObject<List<WaitRead>>(waitread).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var total = list.Count();
            var maxpage = Math.Ceiling(double.Parse(((float)total / pageSize).ToString()));
            var page = new Paged<WaitRead>()
            {
                maxPage = int.Parse(maxpage.ToString()),
                total = total,
                GetList = list
            };
            return Json(page);
        }

        public void GetUserRole(int id)
        {
            var list = HelperHttpClient.GetAll("get", "WaitRead/GetUserRole?id=" + id, null);  //根据登录人的id去查询它的角色
            var userrole = JsonConvert.DeserializeObject<List<Role>>(list);
            foreach (var item in userrole)
            {
                QueryUser(item.RoleId, userrole);
            }
        }

        List<int> tmplist = new List<int>();
        public void QueryUser(int roleid, List<Role> list)
        {
            var userlist = list.Where(m => m.RolePid == roleid).ToList();
            foreach (var item in userlist)
            {
                tmplist.Add(item.RoleId);
                QueryUser(item.RoleId, userlist);
            }
        }

        public JsonResult Intergal(int id)
        {
            GetUserRole(3);
            var list = HelperHttpClient.GetAll("post", "WaitRead/GetIntegralList", tmplist);
            return Json(list);
        }

        /// <summary>
        /// 运行情况
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRunCondition()
        {
            var list = HelperHttpClient.GetAll("get", "WaitRead/GetRunConditionList");  //根据登录人的id去查询它的角色
            var condition = JsonConvert.DeserializeObject<List<GoalStateGoal>>(list);
            List<EchartModel> echartlist = new List<EchartModel>();
            for (int i = 0; i < condition.Count(); i++)
            {
                EchartModel model = new EchartModel();
                model.name = condition[i].GoalState_Name;
                model.value = condition[i].count;
                echartlist.Add(model);
            }
            string tmpdata = JsonConvert.SerializeObject(echartlist);
            return Json(tmpdata);
        }
    }
}