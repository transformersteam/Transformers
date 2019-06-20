using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Model.Dto
{
    public class ApprOpinion
    {
        /// <summary>
        /// 审批人姓名
        /// </summary>
        public string User_Name { get; set; }
        /// <summary>
        /// 审批人执行操作
        /// </summary>
        public int ApprActivity_IsExecute { get; set; }
        /// <summary>
        /// 审批人意见
        /// </summary>
        public string ApprActivity_Opinion { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime ApprActivity_CreateTime { get; set; }
    }
}
