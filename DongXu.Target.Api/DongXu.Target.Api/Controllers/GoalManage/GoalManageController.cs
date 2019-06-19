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
        /// 目标下达
        /// </summary>
        /// <param name="goal"></param>
        /// <returns></returns>
        [HttpPost("GoalAdd")]
        public int GoalAdd(Goal goal)
        {
            int i = iGoalManageRepository.GoalAdd(goal);
            return i;
        }

        /// <summary>
        /// 目标文件 添加
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost("GoalFileAdd")]
        public int GoalFileAdd(Files files)
        {
            int i = iGoalManageRepository.GoalFileAdd(files);
            return i;
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
        /// 查询公司列表 指标单位
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDutyCommanyList")]
        public List<Role> GetDutyCommanyList()
        {
            var list = iGoalManageRepository.GetDutyCommanyList();
            return list;
        }

        /// <summary>
        /// 查询指标类别类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetParentType")]
        public List<Goaltype> GetParentType()
        {
            var list = iGoalManageRepository.GetParentType();
            return list;
        }

        /// <summary>
        /// 查询指标类型  子集
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetChildType")]
        public List<Goaltype> GetChildType()
        {
            var list = iGoalManageRepository.GetChildType();
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

        /// <summary>
        /// 查询指标等级
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetIndexlevelList")]
        public List<Indexlevel> GetIndexlevelList()
        {
            var list = iGoalManageRepository.GetIndexlevelList();
            return list;
        }

        /// <summary>
        /// 查询反馈频次
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFrequencieList")]
        public List<Frequency> GetFrequencieList()
        {
            var list = iGoalManageRepository.GetFrequencieList();
            return list;
        }
    }
}