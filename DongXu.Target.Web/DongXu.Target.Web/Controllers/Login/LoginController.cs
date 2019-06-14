using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using DongXu.Target.Web.Models.Dto;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace DongXu.Target.Web.Controllers
{
    public class LoginController : BaseController
    {
        /// <summary>
        /// 登录视图
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录方法
        /// </summary>
        /// <returns></returns>
        public int LoginIn()
        {
            var name = Request.Form["name"];
            var pass = Request.Form["pwd"];           
            string action = string.Format("Login/Login?UserName={0}&UserPass={1}", name,pass);
            var result= HelperHttpClient.GetAll("get", action,null);
            if (result != null && result != "")
            {
                LoginModel user= (LoginModel)JsonConvert.DeserializeObject(result, typeof(LoginModel));

                var power= string.Format("Login/GetPower?Users_Id={0}", user.userId);
                var jurdata = HelperHttpClient.GetAll("get", power, null);
                // 实例化DataContractJsonSerializer对象，需要待序列化的对象类型
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<PowerList>));
                //把Json传入内存流中保存
                MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jurdata));
                // 使用ReadObject方法反序列化成对象
                object ob = serializer.ReadObject(stream);
                List<PowerList> ls = (List<PowerList>)ob;
                var loginModel = new LoginModel
                {
                    userId = user.userId,
                    userName = user.userName,
                    PowerList = ls
                };
                WriteCookie(loginModel);
                //HttpContext.Session.SetString("User_Id", user.userId.ToString());
                 
                // WriteDataToCookie(loginModel);
                return 1;
            }
            

            return 0;
        }

    }
}