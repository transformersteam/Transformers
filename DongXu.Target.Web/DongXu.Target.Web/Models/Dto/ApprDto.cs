using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DongXu.Target.Web.Models.Dto
{
    public class ApprDto
    {
        /// <summary>
        /// 审批人
        /// </summary>
        public string User_Name { get; set; }
        /// <summary>
        /// 审批状态
        /// </summary>
        public int ApprActivity_IsExecute { get; set; }
        /// <summary>
        /// 下一步id
        /// </summary>
        public int Next_Id { get; set; }
    }
}
