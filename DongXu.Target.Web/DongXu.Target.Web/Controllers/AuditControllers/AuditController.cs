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
        /// 审核首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 审批详情页面
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
    }
}