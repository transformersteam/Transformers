using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Model.Dto
{
    public class UserQuery
    {  
        
        /// <summary>
        /// 用户id
        /// </summary>
        //public int UserId { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        //public string UserName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        //public string UserPass { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        // public string UserRealName { get; set; }

        /// <summary>
        /// 用户角色名称
        /// </summary>
        //public string UserRoleName { get; set; }
        //public string UserRoleName { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        //  public bool UserIsEnable { get; set; }

        public int Power_Id { get; set; }
        public string Power_Name { get; set; }
        public string Power_Url { get; set; }
        public int Power_PId { get; set; }

        public int Power_SortId { get; set; }
        public bool Power_IsEnable { get; set; }

    }
}
