using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DongXu.Target.IRepository;
using DongXu.Target.Model;
using DongXu.Target.Model.Dto;

namespace DongXu.Target.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public ILoginRepository _login = null; 



        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="commodityTypeRepository"></param>
        public LoginController(ILoginRepository loginRepository)
        {
            _login = loginRepository;
        }

        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPass"></param>
        /// <returns></returns>
        [HttpGet]
        public User Login(string UserName, string UserPass)
        {
            var result = _login.Login(UserName, UserPass);

            return result;
        }

        /// <summary>
        /// 登录后获取权限
        /// </summary>
        /// <param name="Users_Id"></param>
        /// <returns></returns>
        [HttpGet]
        public List<UserQuery> GetPower(int UserId)  
        {
            var result = _login.GetPower(UserId);
            return result;
        }

    }
}