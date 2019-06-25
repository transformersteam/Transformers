using DongXu.Target.Cache;
using DongXu.Target.Web.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DongXu.Target.Web
{
    /// <summary>
    /// 动作过滤器
    /// </summary>
    public class MyActionFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 判断是否授权
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var tmpUser = RedisHelper.Get<LoginModel>(filterContext.HttpContext.User.Identity.Name);
                if (tmpUser != null)
                {
                    //获取访问路径
                    var path = filterContext.HttpContext.Request.Path.ToString();

                    //验证是否有访问权限
                    var result = tmpUser.PowerList.Exists(m => m.power_Url.ToLower() == path.ToLower());
                    if (!result)
                    {
                        filterContext.Result = new RedirectResult("/Login");
                    }
                }
            }
            else
            {
                filterContext.Result = new RedirectResult("/Login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}





