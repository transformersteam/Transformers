using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target
{
    public class IntergalUser
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int IntegralId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 积分总数
        /// </summary>
        public int? IntegralNum { get; set; }

        /// <summary>
        /// 目标id
        /// </summary>
        public int Goad_Id { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
    }
}
