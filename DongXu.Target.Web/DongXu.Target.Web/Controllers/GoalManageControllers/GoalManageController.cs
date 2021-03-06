﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DongXu.Target.Cache;
using DongXu.Target.Web.Models;
using DongXu.Target.Web.Models.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
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
        public ActionResult GoalAdd(int pid)
        {
            var username = RedisHelper.Get("username");
            ViewBag.pid = pid;
            ViewBag.username = username;
            return View();
        }
        
        /// <summary>
        /// 设置关注人页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddAttentionUser(int id)
        {
            ViewBag.id = id;    //选择关注人的目标id
            return View();
        }

        /// <summary>
        /// 添加关注人
        /// </summary>
        /// <param name="goalid"></param>
        /// <param name="attentionuser"></param>
        /// <returns></returns>
        [HttpPost]
        public int AttentionSubmit(int goalid,string attentionuser)
        {
            List<Attention> list = new List<Attention>();
            var str = attentionuser.Remove(attentionuser.Length-1).Split(',');
            for (int i = 0; i < str.Length; i++)
            {
                Attention attention = new Attention();
                attention.UserId =Convert.ToInt32(str[i]);
                attention.GoalId = goalid;
                attention.AttentionIsUse = 1;
                attention.AttentionCreateTime =Convert.ToDateTime(DateTime.Now.ToString("yyyy MM dd"));
                list.Add(attention);
            }
            var j = HelperHttpClient.GetAll("post", "GoalManage/AddAttentionUser",list);  //添加成功返回自增长id
            return Convert.ToInt32(j);
        }

        /// <summary>
        /// 目标下达
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GoalSubmit([FromForm]IFormCollection formData,GoalBaseData baseData)
        {
            //添加目标表
            var goal = new Goal()
            {
                GoalName = baseData.GoalName,
                RoleId = baseData.RoleId,
                GoalTypeId = baseData.GoalTypeId,
                FrequencyId = baseData.FrequencyId,
                IndexLevelId = baseData.IndexLevelId,
                GoalStartTime = baseData.GoalStartTime,
                GoalEndTime = baseData.GoalEndTime,
                GoalWeight = baseData.GoalWeight,
                Goal_DutyUserId = baseData.Goal_DutyUserId,
                Goal_DutyCommanyId = baseData.Goal_DutyCommanyId,
                Goal_ParentId = baseData.Goal_ParentId,
                BusinessState = 0,
                FeedbackId = 1,
                FileId = 0,
                GoalCreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy MM dd")),
                GoalFormula = baseData.GoalFormula,
                GoalPeriod = baseData.GoalPeriod,
                GoalSources = baseData.GoalSources,
                GoalInformant = RedisHelper.Get("username"),
                GoalChargePeople = "admin",
                GoalOrganiser = baseData.GoalOrganiser,
                GoalUnit = DateTime.Now.ToString("yyyy MM dd"),
                GoalStateId=4, 
            };
            string auditValue = baseData.AuditValue;   //获取到审核人id
            var goaldata = JsonConvert.SerializeObject(goal);
            var goalId = HelperHttpClient.GetAll("post", "GoalManage/GoalAdd", goaldata);  //添加成功返回自增长id

            //添加到配置表
            ApprconfigurationDto apprconfigurationDto = new ApprconfigurationDto();
            apprconfigurationDto.AuditValue = auditValue;
            apprconfigurationDto.GoalId =int.Parse( goalId);
            AddrConfiguration(apprconfigurationDto);

            //添加进展表
            Feedback feedback = new Feedback();
            feedback.GoalId = int.Parse(goalId);
            feedback.StateId = 1;
            feedback.FeedbackWorkEvolve = "未启动";
            feedback.FeedbackDayEvolve = "完成0%";
            feedback.FeedbackQuestion = "无问题";
            feedback.FeedbackMeasure = "无";
            feedback.FeedbackCoordinateMatters = "无";
            feedback.FeedbackNowEvolve = 0;
            AddFeedBack(feedback);

            //添加指标分解表
            Indexs indexs = new Indexs();
            indexs.IndexsJanuary = baseData.IndexsJanuary;
            indexs.IndexsFebruary = baseData.IndexsFebruary;
            indexs.IndexsMarch = baseData.IndexsMarch;
            indexs.IndexsApril = baseData.IndexsApril;
            indexs.IndexsMay = baseData.IndexsMay;
            indexs.IndexsJune = baseData.IndexsJune;
            indexs.IndexsJuly = baseData.IndexsJuly;
            indexs.IndexsAugust = baseData.IndexsAugust;
            indexs.IndexsSeptember = baseData.IndexsSeptember;
            indexs.IndexsOctober = baseData.IndexsOctober;
            indexs.IndexsNovember = baseData.IndexsNovember;
            indexs.IndexsYearTarget = baseData.IndexsYearTarget;
            indexs.GoalId = int.Parse(goalId);
            indexs.IndexsCreateTime =Convert.ToDateTime(DateTime.Now.ToString("yyyy MM dd"));
            var index= HelperHttpClient.GetAll("post", "GoalManage/GoalIndexsAdd", indexs);  

            //上传文件
            IFormFileCollection files = formData.Files;
            long size = files.Sum(f => f.Length);
            var i ="";
            foreach (var item in files)
            {
                var inputName = item.Name;
                var filePath = "Common/UpdateFiles/" + item.FileName.Substring(item.FileName.LastIndexOf("\\") + 1);
                if (item.Length>0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }
                }
                var file = new Files()
                {
                    FileName = item.FileName,
                    FileUrl = filePath,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy MM dd")),
                    GoalId = int.Parse(goalId),
                };
                i = HelperHttpClient.GetAll("post", "GoalManage/GoalFileAdd", file);
            }
            return Json("目标下达成功，望督促按时完成任务!");
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public FileResult DownLoad(string filename,string filepath)
        {
            try
            {
                var addurl = Path.Combine(Directory.GetCurrentDirectory(), filepath);
                FileStream stream = new FileStream(addurl, FileMode.Open);
                return File(stream, "application/vnd.android.package-archive", filename);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加到配置表
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public JsonResult AddrConfiguration(ApprconfigurationDto apprconfigurationDto)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(apprconfigurationDto);
            var target = HelperHttpClient.GetAll("post", "Audit/AddrConfiguration", json);
            return Json(target);

        }
        /// <summary>
        /// 添加进展表
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns></returns>
        public JsonResult AddFeedBack(Feedback feedback)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(feedback);
            var target = HelperHttpClient.GetAll("post", "Audit/AddFeedBack", json);
            return Json(target);
        }

        /// <summary>
        /// 修改目标状态 是否启用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public int UpdateState(int id)
        {
            var state= HelperHttpClient.GetAll("post", "GoalManage/UpdateGoalState?id="+id, null);
            if (int.Parse(state) > 0)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 获取公司列表  指标单位  公司
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCommanyList()
        {
            var commany = HelperHttpClient.GetAll("get", "GoalManage/GetCommanyList", null);
            var list = JsonConvert.DeserializeObject<List<Role>>(commany);
            return Json(list);
        }
        
        /// <summary>
        /// 获取公司列表  责任单位  部门
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDutyCommanyList()
        {
            var commany = HelperHttpClient.GetAll("get", "GoalManage/GetDutyCommanyList", null);
            var list = JsonConvert.DeserializeObject<List<Role>>(commany);
            return Json(list);
        }

        /// <summary>
        /// 获取目标类型  父级
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetGoalParentTypeList()
        {
            var goaltype= HelperHttpClient.GetAll("get", "GoalManage/GetParentType", null);
            var list = JsonConvert.DeserializeObject<List<Goaltype>>(goaltype);
            return Json(list);
        }

        /// <summary>
        /// 获取目标类型 子集
        /// </summary>
        /// <returns></returns>
        public JsonResult GetGoalChildTypeList()
        {
            var goaltype = HelperHttpClient.GetAll("get", "GoalManage/GetChildType", null);
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

        /// <summary>
        /// 查询指标等级
        /// </summary>
        /// <returns></returns>
        public JsonResult GetIndexlevelList()
        {
            var indexleave= HelperHttpClient.GetAll("get", "GoalManage/GetIndexlevelList", null);
            var list= JsonConvert.DeserializeObject<List<Indexlevel>>(indexleave);
            return Json(list);
        }

        /// <summary>
        /// 查询反馈频次
        /// </summary>
        /// <returns></returns>
        public JsonResult GetFrequencieList()
        {
            var frequency= HelperHttpClient.GetAll("get", "GoalManage/GetFrequencieList", null);
            var list = JsonConvert.DeserializeObject<List<Frequency>>(frequency);
            return Json(list);
        }

        /// <summary>
        /// 根据目标id获取指标分解表数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetIndexsByGoalId(int id)
        {
            var indexlist = HelperHttpClient.GetAll("get", "GoalManage/GetIndexsByGoalId?id="+id, null);
            var list = JsonConvert.DeserializeObject<List<Indexs>>(indexlist);
            return Json(list);
        }

        /// <summary>
        /// 根据目标id获取目标审核人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetUserNameByGoalId(int id)
        {
            var userlist = HelperHttpClient.GetAll("get", "GoalManage/GetUserNameByGoalId?id=" + id, null);
            var list = JsonConvert.DeserializeObject<List<AuditUser>>(userlist);
            return Json(list);
        }
    }
}