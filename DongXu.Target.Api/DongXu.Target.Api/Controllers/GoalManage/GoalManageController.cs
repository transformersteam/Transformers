using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DongXu.Target.IRepository.IGoalManage;
using DongXu.Target.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public int GoalAdd([FromBody]string goal)
        {
            var list = JsonConvert.DeserializeObject<Goal>(goal);
            int i = iGoalManageRepository.GoalAdd(list);
            return i;
        }

        /// <summary>
        /// 目标文件 添加
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost("GoalFileAdd")]
        public int GoalFileAdd([FromBody]Files files)
        {
            int i = iGoalManageRepository.GoalFileAdd(files);
            return i;
        }

        /// <summary>
        /// 目标分解表 添加
        /// </summary>
        /// <param name="indexs"></param>
        /// <returns></returns>
        [HttpPost("GoalIndexsAdd")]
        public int GoalIndexsAdd([FromBody]Indexs indexs)
        {
            int i = iGoalManageRepository.GoalIndexsAdd(indexs);
            return i;
        }

        /// <summary>
        /// 批量插入 关注人
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost("AddAttentionUser")]
        public int AddAttentionUser([FromBody]List<Attention> list)
        {
            int i = iGoalManageRepository.AddAttentionUser(list);
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

        /// <summary>
        /// 根据目标id查询对应指标分解
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetIndexsByGoalId")]
        public List<Indexs> GetIndexsByGoalId(int id)
        {
            var list = iGoalManageRepository.GetIndexsByGoalId(id);
            return list;
        }

        /// <summary>
        /// 根据目标id获取目标审核人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetUserNameByGoalId")]
        public List<AuditUser> GetUserNameByGoalId(int id)
        {
            var list = iGoalManageRepository.GetUserNameByGoalId(id);
            return list;
        }
    }
}