using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        public ActionResult GoalAdd()
        {
            return View();
        }

        /// <summary>
        /// 目标下达
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GoalSubmit([FromForm]IFormCollection formData,GoalBaseData baseData)
        {
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
                GoalCreateTime =Convert.ToDateTime(DateTime.Now.ToString("yyyy MM dd")),
                GoalFormula=baseData.GoalFormula,
                GoalPeriod =baseData.GoalPeriod,
                GoalSources=baseData.GoalSources,
                GoalStateId=4,                       
            };
            string auditValue = baseData.AuditValue;
            var goaldata = JsonConvert.SerializeObject(goal);
            var goalId = HelperHttpClient.GetAll("post", "GoalManage/GoalAdd", goaldata);  //添加成功返回自增长id

            //添加到配置表
            ApprconfigurationDto apprconfigurationDto = new ApprconfigurationDto();
            apprconfigurationDto.AuditValue = auditValue;
            apprconfigurationDto.GoalId =int.Parse( goalId);
            AddrConfiguration(apprconfigurationDto);

            Apprconfiguration config = new Apprconfiguration();
            for (int i = 0; i < baseData.AuditValue.Length; i++)
            {
                config.ApprConfigurationCreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy MM dd"));
                config.GoalId = int.Parse(goalId);
                config.ApprConfigurationIsEnable = 1;
                //config.
            }

            IFormFileCollection files = formData.Files;
            long size = files.Sum(f => f.Length);
            foreach (var item in files)
            {
                var inputName = item.Name;
                var filePath = @"F:\360Downloads\" + item.FileName.Substring(item.FileName.LastIndexOf("\\") + 1);
                if(item.Length>0)
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
                var i = HelperHttpClient.GetAll("post", "GoalManage/GoalFileAdd", file);
            }
            return Ok(new { count = files.Count, size });
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
    }
}