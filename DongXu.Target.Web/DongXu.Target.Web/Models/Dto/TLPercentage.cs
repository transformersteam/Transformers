using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Web.Models.Dto
{
    public class TLPercentage
    {
        /// <summary>
        /// 红灯
        /// </summary>
        public decimal RedLight { get; set; }

        /// <summary>
        /// 黄灯
        /// </summary>
        public decimal YellowLight { get; set; }

        /// <summary>
        /// 绿灯 
        /// </summary>
        public decimal GreenLight { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public decimal TargetNumber { get; set; }
    }
}
