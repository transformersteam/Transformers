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
    public class OrganizationController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IOrganizationRepository _organization;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="organization"></param>
        public OrganizationController(IOrganizationRepository organization)
        {
            _organization = organization;
        }

        /// <summary>
        /// 组织管理
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetRolesOList")]
        public List<Role> GetRolesOList()
        {
            return _organization.GetRolesOList();
        }


        [HttpGet("GetRolesOListById")]
        public Role GetRolesOListById(int RoleId)
        {
            return _organization.GetRolesOListById(RoleId);
        }


        [HttpPost("AddRolesO")]
        public int AddRolesO(Role model)
        {
            return _organization.AddRolesO(model);
        }


        [HttpGet("DeleteRolesO")]
        public int DeleteRolesO(int id)
        {
            return _organization.DeleteRolesO(id);
        }


        [HttpPost("UpdateRolesOName")]
        public int UpdateRolesOName(Role model)
        {
            return _organization.UpdateRolesOName(model);
        }


        [HttpPost("UpdateRolesO")]
        public int UpdateRolesO([FromBody]string json)
        {
            Role model = Newtonsoft.Json.JsonConvert.DeserializeObject<Role>(json);
            return _organization.UpdateRolesO(model);
        }


        /// <summary>
        /// 岗位管理
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpGet("GetRolesGList")]
        public List<Role> GetRolesGList()
        {
            return _organization.GetRolesGList();
        }


        [HttpGet("GetRolesRList")]
        public List<Role> GetRolesRList()
        {
            return _organization.GetRolesRList();
        }
        //[HttpGet("GetRoleUserQueryList")]
        //public List<RoleUserQuery> GetRoleUserQueryList(int RoleId)
        //{
        //    return _organization.GetRoleUserQueryList(RoleId);
        //}

        /// <summary>
        /// 岗位维护，当前部门下的角色
        /// </summary>
        /// <returns></returns>
        [HttpGet("ChlidrenUserByRole")]
        public DataTable ChlidrenUserByRole(int id)
        {
            var query = _organization.ChlidrenUserByRole(id);
            return query;
        }


        /// <summary>
        /// 删除角色,停用
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        [HttpGet("DeleteUser")]
        public int DeleteUser(int userid)
        {
            var query = _organization.DeleteUser(userid);
            return query;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("AddUser")]
        public int AddUser([FromBody]User user)
        {
            var query = _organization.AddUser(user);
            return query;
        }
        //查询所有权限
        [HttpGet("GetPowerList")]
        public List<Power> GetPowerList()
        {
            var list = _organization.GetPowerList();
            return list;
        }
    }
}