using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Web.Models.Dto
{
    public class TrafficLightRanking
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public string Role_Name { get; set; }

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
        /// 公司名称
        /// </summary>
        public decimal TargetNumber { get; set; }

        /// <summary>
        /// 红灯百分比
        /// </summary>
        public decimal RedLightPercentage { get; set; }

        /// <summary>
        /// 黄灯百分比
        /// </summary>
        public decimal YellowLightPercentage { get; set; }

        /// <summary>
        /// 绿灯百分比
        /// </summary>
        public decimal GreenLightPercentage { get; set; }
    }
}
