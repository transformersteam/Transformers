﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DongXu.Target.Web.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DongXu.Target.Web.Controllers.TrafficLightRankingController
{
    public class TrafficLightRankingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //三个参数第一个参数是他的Http请求方法 第二个是方法名称  第三个是对象参数
        public string GetAll(string request, string actionName, object obj = null)
        {
            //创建返回字符串
            string json = "";
            //实例化HTTP客户端
            HttpClient hc = new HttpClient();
            //配置HTTP客户端要访问的服务器地址 主机名+端口+API+控制器+/
            hc.BaseAddress = new Uri("http://localhost:8888/api/TrafficLightRanking/");
            //创建取服务端回包的任务
            Task<HttpResponseMessage> task = null;

            //根据不同的请求方式,发送不同的请求包
            switch (request)
            {
                //tcp/ip 第一次握手 客户端hc发送请求包
                case "get": task = hc.GetAsync(actionName); break;
                case "post": task = hc.PostAsJsonAsync(actionName, obj); break;
                case "put": task = hc.PutAsJsonAsync(actionName, obj); break;
                case "delete": task = hc.DeleteAsync(actionName); break;
            }
            task.Wait();
            //tcp/ip 第二次握手 客户端hc接收回包
            var result = task.Result;
            //tcp/ip 第三次握手 客户端hc确认回包完整性
            if (result.IsSuccessStatusCode)
            {
                //获取回包里面我们所需的数据转化为字符串
                var getresultstringTask = result.Content.ReadAsStringAsync();

                getresultstringTask.Wait();
                //获取转换为字符串的最终结果
                json = getresultstringTask.Result;
            }
            return json;
        }

        /// <summary>
        /// 红绿灯百分比显示
        /// </summary>
        /// <returns></returns>
        public IActionResult Show()
        {
            return View();
        }

        ///// <summary>
        ///// 积分
        ///// </summary>
        ///// <returns></returns>
        //public JsonResult Indexecharts()
        //{
        //    var list = GetAll("get", "GetTrafficLightRankingList");
        //    List<TrafficLightRanking> echartvalue = JsonConvert.DeserializeObject<List<TrafficLightRanking>>(list);
        //    test t = new test();
        //    List<decimal> RedlistNum = new List<decimal>();
        //    List<decimal> YellowlistNum = new List<decimal>();
        //    List<decimal> GreenlistNum = new List<decimal>();
        //    List<string> listName = new List<string>();
        //    foreach (var item in echartvalue)
        //    {
        //        listName.Add(item.Role_Name);
        //        RedlistNum.Add(item.RedLightPercentage);
        //        YellowlistNum.Add(item.YellowLightPercentage);
        //        GreenlistNum.Add(item.GreenLightPercentage);
        //    }

        //    t.NameList = listName;
        //    t.RedNumList = RedlistNum;
        //    t.YellowNumList = YellowlistNum;
        //    t.GreenNumList = GreenlistNum;
        //    return Json(t);
        //}

        //public class test
        //{
        //    public List<string> NameList { get; set; }
        //    public List<decimal> RedNumList { get; set; }
        //    public List<decimal> YellowNumList { get; set; }
        //    public List<decimal> GreenNumList { get; set; }
        //    public List<decimal> NumList { get; set; }
        //}
    }




}