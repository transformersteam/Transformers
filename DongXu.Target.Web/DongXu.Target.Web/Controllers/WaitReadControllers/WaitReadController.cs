using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public ActionResult ManagementShow(int id = 1)
        {
            ViewBag.id = id;   //登录人id
            return View();
        }


        /// <summary>
        /// 待办 已办 待阅
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public JsonResult GetWaitDoList(int id,int state)
        {
            var data = HelperHttpClient.GetAll("get", "WaitRead/GetWaitReadList?id=" + id + "&state=" + state, null);
            var list = JsonConvert.DeserializeObject<List<WaitRead>>(data);
            return Json(list);
        }

        /// <summary>
        /// 目标详情页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult TargetDetails(int id, int progressid)
        {
            ViewBag.id = id;
            ViewBag.progressid = progressid;
            return View();
        }

        /// <summary>
        /// 根据id显示目标详情信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DetailsShow(int id)
        {
            var target = HelperHttpClient.GetAll("get", "WaitRead/GetTargetDetailById?id=" + id, null);
            var list = JsonConvert.DeserializeObject<List<TargetDetails>>(target);
            return Json(list);
        }

        /// <summary>
        /// 用户积分
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetIntergalUser(int id)
        {
            List<int> datacount = new List<int>();
            List<string> dataname = new List<string>();
            var model = HelperHttpClient.GetAll("get", "WaitRead/GetUserIntergal?id=" + id, null);
            var list = JsonConvert.DeserializeObject<List<UserIntegral>>(model).OrderByDescending(m => m.Integral_Num);
            EchartModel echartModel = new EchartModel();
            foreach (var item in list)
            {
                echartModel.name = item.User_Name;
                echartModel.value = item.Integral_Num;
                datacount.Add(echartModel.value);
                dataname.Add(echartModel.name);
            }
            echartModel.dataname = dataname;
            echartModel.datacount = datacount;
            return Json(echartModel);
        }

        /// <summary>
        /// 运行情况Echarts
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEchartRunCondition()
        {
            List<int> datacount = new List<int>();
            List<string> dataname = new List<string>();
            var list = HelperHttpClient.GetAll("get", "WaitRead/GetRunConditionList");
            var condition = JsonConvert.DeserializeObject<List<GoalStateGoal>>(list);
            EchartModel echartModel = new EchartModel();
            foreach (var item in condition)
            {
                echartModel.name = item.GoalState_Name;
                echartModel.value = item.count;
                datacount.Add(echartModel.value);
                dataname.Add(echartModel.name);
            }
            echartModel.dataname = dataname;
            echartModel.datacount = datacount;
            return Json(echartModel);
        }

        /// <summary>
        /// 运行情况表格
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRunCondition()
        {
            var list = HelperHttpClient.GetAll("get", "WaitRead/GetRunConditionList");
            var condition = JsonConvert.DeserializeObject<List<GoalStateGoal>>(list);
            return Json(condition);
        }

        /// <summary>
        /// 红绿灯状态表格
        /// </summary>
        /// <returns></returns>
        public JsonResult GetBusinessStateTableList()
        {
            var list = HelperHttpClient.GetAll("get", "WaitRead/GetBusinessStateTable");
            var statelist = JsonConvert.DeserializeObject<List<BusinessStateTable>>(list);
            return Json(statelist);
        }
    }
}