using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PagedList.Core;
using Webdiyer.WebControls.Mvc;
using X.PagedList.Mvc.Core;

namespace DongXu.Target.Web.Controllers.ScheduleControllers
{
    public class WeekSearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 周报查询
        /// </summary>
        /// <returns></returns>
        public ActionResult WeekShow(int pageIndex=1, int pageSize=5, string goalName="", int typeId=0, int leaveId = 0, int stateId = 0, string dutyCommanyName="", string dutyUserName="",string goaltime="")
        {
            WeekQueryData data = new WeekQueryData();
            data.pageIndex = pageIndex;
            data.pageSize = pageSize;
            data.goalName = goalName;
            data.typeId = typeId;
            data.leaveId = leaveId;
            data.stateId = stateId;
            data.dutyCommanyName = dutyCommanyName;
            data.dutyUserName = dutyUserName;
            data.goaltime = goaltime;
            var weekdata = HelperHttpClient.GetAll("post","WeekQuery/GetWeekList",data);
            var list = JsonConvert.DeserializeObject<PageData<WeekData>>(weekdata);
            X.PagedList.StaticPagedList<WeekData> pagelist = new X.PagedList.StaticPagedList<WeekData>(list.GetData, pageIndex, pageSize,25);
            return View(pagelist);
        }
    }
}