using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DongXu.Target.IRepository.IGoalManage;
using DongXu.Target.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DongXu.Target.Api.Controllers.GoalManage
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalManageController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IGoalManageRepository iGoalManageRepository;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        public GoalManageController(IGoalManageRepository _iGoalManageRepository)
        {
            iGoalManageRepository = _iGoalManageRepository;
        }

        /// <summary>
        /// 目标管理 绑定目标树
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetGoalList")]
        public List<Goal> GetGoalList()
        {
            var list = iGoalManageRepository.GetGoalList();
            return list;
        }

        /// <summary>
        /// 查询公司列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCommanyList")]
        public List<Role> GetCommanyList()
        {
            var list = iGoalManageRepository.GetCommanyList();
            return list;
        }

        /// <summary>
        /// 查询指标类别类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetParentType")]
        public List<Goaltype> GetParentType(int id)
        {
            var list = iGoalManageRepository.GetParentType(id);
            return list;
        }

        /// <summary>
        /// 查询责任人
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDutyUserList")]
        public List<User> GetDutyUserList()
        {
            var list = iGoalManageRepository.GetDutyUserList();
            return list;
        }

        /// <summary>
        /// 查询协办人
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDothingUserList")]
        public List<User> GetDothingUserList()
        {
            var list = iGoalManageRepository.GetDothingUserList();
            return list;
        }
    }
}