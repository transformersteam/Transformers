using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DongXu.Target.IRepository;
using DongXu.Target.Model;
using DongXu.Target.IRepository.IOrganization;

namespace DongXu.Target.Api.Controllers.OrganizationController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IOrganization _organization;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="organization"></param>
        public OrganizationController(IOrganization organization)
        {
            _organization = organization;
        }
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
    }
}