using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DongXu.Target.IRepository;
using DongXu.Target.Model;
using DongXu.Target.IRepository.IOrganization;
using DongXu.Target.Model.Dto;
using MySql.Data.MySqlClient;
using System.Data;

namespace DongXu.Target.Api.Controllers.OrganizationController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {

        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IAuthorizationRepository _authorization;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="organization"></param>
        public AuthorizationController(IAuthorizationRepository authorization)
        {
            _authorization = authorization;
        }
        /// <summary>
        /// 显示人员
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUserList")]
        public List<User> GetUserList()
        {
            return _authorization.GetUserList();
        }
        /// <summary>
        /// 添加人员
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost("AddUser")]
        public int AddUser([FromBody]string json)
        {
            User user= Newtonsoft.Json.JsonConvert.DeserializeObject<User>(json);
            return _authorization.AddUser(user);
        }
        /// <summary>
        /// 添加人员 角色关联
        /// </summary>
        [HttpPost("AddUserrole")]
        public int AddUserrole([FromBody]string json)
        {
            UserRoleDto userrole = Newtonsoft.Json.JsonConvert.DeserializeObject<UserRoleDto>(json);
            int uid = userrole.Uid;
            int[] RoleId = Newtonsoft.Json.JsonConvert.DeserializeObject<int[]>(userrole.RoleId);
            return _authorization.AddUserrole(uid, RoleId);
        }
        /// <summary>
        /// 删除人员
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        [HttpPost("DeleteUser")]
        public int DeleteUser([FromBody]int userid)
        {
            return _authorization.DeleteUser(userid);
        }
        //反填人员
        [HttpGet("GetUserById")]
        public User GetUserById(int userId)
        {
            return _authorization.GetUserById(userId);
        }
        //反填人员角色
        [HttpGet("GetUserroleById")]
        public List<Userrole> GetUserroleById(int userId)
        {
            return _authorization.GetUserroleById(userId);
        }
        //修改权限
        [HttpPost("UpdateUser")]
        public int UpdateUser(UpdateUserDto model)
        {
            int[] p = Newtonsoft.Json.JsonConvert.DeserializeObject<int[]>(model.Role);
            User user = new User();
            user.UserId = model.UserId;
            user.UserRealName = model.UserRealName;
            user.User_IdentityId = model.User_IdentityId;
            user.UserRoleName = model.UserRoleName;
            return _authorization.UpdateUser(user, p);
        }
    }
}