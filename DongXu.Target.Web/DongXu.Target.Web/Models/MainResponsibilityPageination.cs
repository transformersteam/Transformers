using DongXu.Target.Web.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Web.Models
{
    public class MainResponsibilityPageination
    {
        /// <summary>
        /// 最大页数
        /// </summary>
        public int maxPage { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 状态集合
        /// </summary>
        public List<MainResponsibility> MainResponsibilityList { get; set; } 
    }
}
