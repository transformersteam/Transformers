using DongXu.Target.Cache;
using DongXu.Target.Web.Models.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace DongXu.Target.Web.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public LoginModel LoginInfo
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    var tmpuserInfo = RedisHelper.Get<LoginModel>(User.Identity.Name);
                    return tmpuserInfo;
                }
                return null;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="tmpUser"></param>
        public void WriteCookie(LoginModel tmpUser)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, tmpUser.userName));

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            //存储redis
            RedisHelper.Set<LoginModel>(tmpUser.userName, tmpUser);

            ////取Redis-测试
            //var tmpUser = RedisHelper.Get<UserInfo>(tmpUser.UserName);
        }

        /// <summary>
        /// 动作过滤器-动作执行之前的事件
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            controller.ViewBag.LoginInfo = LoginInfo;
            base.OnActionExecuting(filterContext);
        }
    }
}