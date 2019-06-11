using System;
using System.Collections.Generic;
using System.Text;
using DongXu.Target.Model;
namespace DongXu.Target.IRepository
{
    public interface IOrganization
    {
        List<Role> GetRolesOList(int Identify);
        int AddRolesO(Role model);
        int DeleteRolesO(int id);
        Role GetRolesById(int id);
        int UpdateRolesO(Role model);
    }
}
