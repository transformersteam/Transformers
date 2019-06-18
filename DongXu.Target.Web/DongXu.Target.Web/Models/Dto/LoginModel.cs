using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DongXu.Target.Web.Models.Dto
{


   public class LoginModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int userId { get; set; } 

        /// <summary>
        /// 用户名称
        /// </summary>
        public string userName { get; set; } 

        /// <summary>
        /// 用户角色
        /// </summary>
        public int Role_Id { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string userPass { get; set; } 

        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string userRealName { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Role_Name { get; set; }

        /// 权限ID
        /// </summary>
        public int Jurisdiction_Id { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Jurisdiction_Name { get; set; }

        /// <summary>
        /// 权限url
        /// </summary>
        public string Power_Url { get; set; } 

        public List<Role> RoleList { get; set; }

        /// <summary>
        /// 权限列表
        /// </summary>
        public List<PowerList> PowerList { get; set; } 


    }




    //角色列表
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    //权限列表
    public class PowerList  
    {
        public int UserId { get; set; } 
        public string power_Name { get; set; } 
        public string power_Url { get; set; } 
    }

}
