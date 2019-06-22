using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using DongXu.Target.Cache;
using DongXu.Target.Web.Models.Dto;
namespace DongXu.Target.Web.Controllers.AuditControllers
{
    public class AuditController : Controller
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(int id=59,int proess=1)
        {
            ViewBag.id = id;
            ViewBag.user = 4;
            return View();
        }
        /// <summary>
        /// 显示审批详情页面
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="goalId"></param>
        /// <returns></returns>
        public JsonResult GetAuditDtoList(int userId, int goalId)
        {
            var result = HelperHttpClient.GetAll("get", "Audit/GetAuditDtoList?userId=" + userId + "&goalId=" + goalId, null);
            var auditDtoList = Newtonsoft.Json.JsonConvert.DeserializeObject<AuditDto>(result);
            List<AuditDto> list = new List<AuditDto>();
            list.Add(auditDtoList);
            return Json(list);
        }
        /// <summary>
        /// 审批流程
        /// </summary>
        /// <param name="goalId"></param>
        /// <returns></returns>
        public JsonResult GetApprDtoList(int goalId)
        {
            var result = HelperHttpClient.GetAll("get", "Audit/GetApprDtoList?goalId=" + goalId,null);
            var apparDtoList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ApprDto>>(result);
            return Json(apparDtoList);
        }
        /// <summary>
        /// 审批意见
        /// </summary>
        /// <param name="goalId"></param>
        /// <returns></returns>
        public JsonResult GetApprOpinionList(int goalId)
        {
            var result = HelperHttpClient.GetAll("get", "Audit/GetApprOpinionList?goalId=" + goalId, null);
            var apprOpinionList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ApprOpinion>>(result);
            return Json(apprOpinionList);
        }
        /// <summary>
        /// 审批流程
        /// </summary>
        /// <param name="goalId"></param>
        /// <returns></returns>
        public JsonResult GetApprFlowList(int goalId)
        {
            var result = HelperHttpClient.GetAll("get", "Audit/GetApprFlowList?goalId=" + goalId, null);
            var apprOpinionList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ApprOpinion>>(result);
            return Json(apprOpinionList);
        }
        /// <summary>
        /// 审批
        /// </summary>
        /// <param name="appractivity"></param>
        /// <returns></returns>
        public JsonResult Audit(AuditauditDto appractivity)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(appractivity);
            var result = HelperHttpClient.GetAll("post", "Audit/Audit", json);
            return Json(result);
        }
    }
}