using System;
using System.Collections.Generic;
using System.Text;
using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
namespace DongXu.Target.IRepository.IOrganization
{
     public interface IAuthorizationRepository
    {
        //显示人员
        List<User> GetUserList();
        //查询角色
        List<Role> GetRoleList();
        //添加人员
        int AddUser(User model);
        //添加人员角色关联
        int AddUserrole(int uid, int[] role);
        //删除人员
        int DeleteUser(int id);
        //反填人员
        User GetUserById(int userId);
        //反填人员角色
        List<Userrole> GetUserroleById(int userId);
        //修改人员角色
        int UpdateUser(User model, int[] role);
    }
}
