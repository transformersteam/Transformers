using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Model.Dto
{
    public class RoleUserQuery
    {
            /// <summary>
            /// 主键id
            /// </summary>
            public int RoleId { get; set; }

            /// <summary>
            /// 角色名称
            /// </summary>
            public string RoleName { get; set; }

            /// <summary>
            /// 父级id
            /// </summary>
            public int RolePid { get; set; }

            /// <summary>
            /// 内容
            /// </summary>
            public string RoleContent { get; set; }

            /// <summary>
            /// 是否启用
            /// </summary>
            /// 
            public int RoleIsEnable { get; set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            public DateTime? RoleCreateTime { get; set; }

            /// <summary>
            /// 创建人
            /// </summary>
            public string RoleCreatePeople { get; set; }

            /// <summary>
            /// 修改人
            /// </summary>
            public string RoleModifyPeople { get; set; }

            /// <summary>
            /// 修改时间
            /// </summary>
            public DateTime? RoleModifyTime { get; set; }

            //标识列
            public int RoleIdentify { get; set; }
            /// <summary>
            /// 用户id
            /// </summary>
            public int UserId { get; set; }

            /// <summary>
            /// 用户名称
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// 用户密码
            /// </summary>
            public string UserPass { get; set; }

            /// <summary>
            /// 真实姓名
            /// </summary>
            public string UserRealName { get; set; }

            /// <summary>
            /// 用户角色名称
            /// </summary>
            public string UserRoleName { get; set; }

            /// <summary>
            /// 是否启用
            /// </summary>
            public bool UserIsEnable { get; set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            public DateTime? UserCreateTime { get; set; }
            /// <summary>
           /// 主键id
            /// </summary>
            public int UserRoleId { get; set; }

    }
}
