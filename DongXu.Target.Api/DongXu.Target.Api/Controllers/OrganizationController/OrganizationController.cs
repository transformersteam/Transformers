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
        public int AddUser(AddUser user)
        {
            var query = _organization.AddUser(user);
            return 1;
        }


        /// <summary>
        /// 获取该部门下所有职业
        /// </summary>
        /// <param name="Role_Id"></param>
        /// <returns></returns>
        [HttpGet("ChildrenJobByRole")]
        public DataTable ChildrenJobByRole(int Role_Id)
        {
            var query = _organization.ChildrenJobByRole(Role_Id);
            return query;
        }


        //查询所有权限
        [HttpGet("GetPowerList")]
        public List<Power> GetPowerList()
        {
            var list = _organization.GetPowerList();
            return list;
        }
        //添加角色
        [HttpPost("AddRole")]
        public int AddRole([FromBody]string json)
        {
            Role role = Newtonsoft.Json.JsonConvert.DeserializeObject<Role>(json);
            return _organization.AddRole(role);
        }
        //添加角色 关联
        [HttpPost("AddRolepower")]
        public int AddRolepower([FromBody]string json)
        {
            RolePower rp = Newtonsoft.Json.JsonConvert.DeserializeObject<RolePower>(json);
            int rid = rp.Rid;
            int[] intLst = Newtonsoft.Json.JsonConvert.DeserializeObject<int[]>(rp.Power);
            return _organization.AddRolepower(rid, intLst);
        }
        //删除角色
        [HttpPost("DeleteRolesR")]
        public int DeleteRolesR([FromBody]int id)
        {
            return _organization.DeleteRolesR(id);
        }
        //反填角色
        [HttpGet("GetRoleById")]
        public Role GetRoleById(int roleId)
        {
            return _organization.GetRoleById(roleId);
        }
        //反填权限
        [HttpGet("GetRolepowerById")]
        public List<Rolepower> GetRolepowerById(int roleId)
        {
            return _organization.GetRolepowerById(roleId);
        }
        //修改权限
        [HttpPost("UpdateRoles")]
        public int UpdateRoles(UpdateRoleDto model)
        {
            int[] p= Newtonsoft.Json.JsonConvert.DeserializeObject<int[]>(model.power);
            Role role = new Role();
            role.RoleId = model.RoleId;
            role.RoleName = model.RoleName;
            role.RolePid = model.RolePid;
            role.RoleContent = model.RoleContent;
            role.RoleModifyPeople = model.RoleModifyPeople;
            role.RoleModifyTime = model.RoleModifyTime;
            return _organization.UpdateRoles(role, p);
        }
    }
}