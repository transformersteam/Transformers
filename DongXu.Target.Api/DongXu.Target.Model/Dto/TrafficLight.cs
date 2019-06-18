using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Model.Dto
{
    public class TrafficLight 
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

    }
}
