using System;
using System.Collections.Generic;
using System.Text;
using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
namespace DongXu.Target.IRepository.IOrganization
{
    public interface IOrganization
    {
        List<Role> GetRolesOList();
        int AddRolesO(Role model);
        int DeleteRolesO(int id);
        Role GetRolesById(int id);
        int UpdateRolesO(Role model);
        Role GetRolesOListById(int RoleId);
        int UpdateRolesOName(Role model);
        List<Role> GetRolesRList();
        RoleUserQuery GetRoleUserQueryList(int RoleId);
        List<User> GetUsersList();
        //RoleUserQuery GetRoleUserQueryListById(int RoleId);
    }
}
