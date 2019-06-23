using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Model.Dto
{
    public class PowerDto
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int Power_Id { get; set; }
        /// <summary>
        /// 权限名字
        /// </summary>
        public string Power_Name { get; set; }
        /// <summary>
        /// 权限Url
        /// </summary>
        public string Power_Url { get; set; }
        /// <summary>
        /// 权限Pid
        /// </summary>
        public int Power_PId { get; set; }
    }
}
