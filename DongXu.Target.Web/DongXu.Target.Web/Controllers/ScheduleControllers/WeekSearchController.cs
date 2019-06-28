using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DongXu.Target.Cache;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using PagedList.Core;
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
        /// 周报查询页面
        /// </summary>
        /// <returns></returns>
        public ActionResult WeekShow(int pageIndex=1, int pageSize=5, string goalName="", int typeId=0, int leaveId = 0, int stateId = 0, string dutyCommanyName="", string dutyUserName="",string begintime="",string endtime="")
        {
            return View();
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public JsonResult GetWeekData(int pageIndex = 1, int pageSize = 5, string goalName = "", int typeId = 0, int leaveId = 0, int stateId = 0, string dutyCommanyName = "", string dutyUserName = "", string begintime = "", string endtime = "")
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
            data.begintime = begintime;
            data.endtime = endtime;
            var weekdata = HelperHttpClient.GetAll("post", "WeekQuery/GetWeekList", data);
            var list = JsonConvert.DeserializeObject<PageData<WeekData>>(weekdata);
            RedisHelper.Set("weekdata", list);
            return Json(list);
        }

        /// <summary>
        /// Excel导出
        /// </summary>
        /// <returns></returns>
        public ActionResult Export()
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("周报数据列表");
            CreateHeadRow(sheet);
            var data = RedisHelper.Get<PageData<WeekData>>("weekdata");    
            int index = 1;
            foreach (var item in data.GetData)
            {
                var row = sheet.CreateRow(index++);
                row.CreateCell(0).SetCellValue(item.Goal_Id);
                row.CreateCell(1).SetCellValue(item.Goal_Name);
                row.CreateCell(2).SetCellValue(item.IndexLevel_Grade);
                row.CreateCell(3).SetCellValue(item.GoalType_Name);
                row.CreateCell(4).SetCellValue(item.Role_Name);
                row.CreateCell(5).SetCellValue(item.User_Name);
                row.CreateCell(6).SetCellValue(item.GoalYear);
                row.CreateCell(7).SetCellValue("已提报");
                row.CreateCell(8).SetCellValue(item.Goal_StartTime);
                row.CreateCell(9).SetCellValue(item.Feedback_DayEvolve);
                row.CreateCell(10).SetCellValue(item.GoalState_Id);
            }
            MemoryStream stream = new MemoryStream();
            workbook.Write(stream);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/ms-excel", $"周报进度_{DateTime.Now.ToString("yyyyMMdd")}.xls");
        }

        /// <summary>
        /// 创建Excel表头
        /// </summary>
        /// <param name="sheet"></param>
        void CreateHeadRow(ISheet sheet)
        {
            var row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("序号");
            row.CreateCell(1).SetCellValue("目标名称");
            row.CreateCell(2).SetCellValue("级别");
            row.CreateCell(3).SetCellValue("类别");
            row.CreateCell(4).SetCellValue("责任部门");
            row.CreateCell(5).SetCellValue("责任人");
            row.CreateCell(6).SetCellValue("年份");
            row.CreateCell(7).SetCellValue("提报状态");
            row.CreateCell(8).SetCellValue("提报日期");
            row.CreateCell(9).SetCellValue("当周进展");
            row.CreateCell(10).SetCellValue("状态");
        }

        /// <summary>
        /// 绑定目标类型
        /// </summary>
        /// <returns></returns>
        public JsonResult GetStateList()
        {
            var state = HelperHttpClient.GetAll("get", "WeekQuery/GetStateList",null);
            var list = JsonConvert.DeserializeObject<List<Goalstate>>(state);
            return Json(list);
        }
    }
}