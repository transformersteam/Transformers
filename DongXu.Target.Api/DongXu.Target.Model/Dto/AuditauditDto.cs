using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Model.Dto
{
    public class AuditauditDto
    {
        /// <summary>
        /// 活动表id
        /// </summary>
        public int ApprActivity_Id { get; set; }
        /// <summary>
        /// 意见
        /// </summary>
        public string ApprActivity_Opinion { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int ApprActivity_IsExecute { get; set; }
        /// <summary>
        /// 下一步id
        /// </summary>
        public int Next_Id { get; set; }
        ///目标id
        public int Goal_Id { get; set; }
    }
}
