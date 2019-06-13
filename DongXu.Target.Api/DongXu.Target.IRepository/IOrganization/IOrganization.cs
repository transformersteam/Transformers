using System;
using System.Collections.Generic;
using System.Text;
using DongXu.Target.Model;
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
    }
}
