using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
namespace DongXu.Target.IRepository.IOrganization
{
    public interface IOrganizationRepository
    {
        List<Role> GetRolesOList();
        int AddRolesO(Role model);
        int DeleteRolesO(int id);
        Role GetRolesById(int id);
        int UpdateRolesO(Role model);
        Role GetRolesOListById(int RoleId);
        int UpdateRolesOName(Role model);
        List<Role> GetRolesGList();
        RoleUserQuery GetRoleUserQueryList(int RoleId);
        List<Role> GetRolesRList();
        DataTable ChlidrenUserByRole(int id);
        int DeleteUser(int userid);

        int AddUser(AddUser addUser);
        DataTable ChildrenJobByRole(int Role_Id);

        //查询权限
        List<Power> GetPowerList();
        //添加角色
        int AddRole(Role model);
        //添加角色权限关联
        int AddRolepower(int rid,int[] power);
        //删除角色
        int DeleteRolesR(int id);
        //反填角色
        Role GetRoleById(int roleId);
        //反填权限
        Rolepower GetRolepowerById(int roleId);
        //RoleUserQuery GetRoleUserQueryListById(int RoleId);
    }
}
