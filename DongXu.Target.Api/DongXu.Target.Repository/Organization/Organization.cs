using DongXu.Target.Model;
using System.Collections.Generic;
using System.Linq;
using DongXu.Target.IRepository.IOrganization;

namespace DongXu.Target.Repository
{
    public class Organization : IOrganization
    {
        dxdatabaseContext db = new dxdatabaseContext();

        public int AddRolesO(Role model)
        {
            db.Role.Add(model);
            return db.SaveChanges();
        }


        public int DeleteRolesO(int id)
        {
            var roleo = db.Role.Where(m => m.RoleId == id).FirstOrDefault();
            db.Role.Remove(roleo);
            return db.SaveChanges();
        }

        public Role GetRolesById(int id)
        {
            return db.Role.Where(m => m.RoleId == id).FirstOrDefault();
        }

        public List<Role> GetRolesOList()
        {
            List<Role> list= db.Role.Where(m => m.RoleIdentify != 3).ToList();
            return list;
        }

        public int UpdateRolesO(Role model)
        {
            var oldrole = db.Role.Where(m => m.RoleId == model.RoleId).FirstOrDefault();
            if(oldrole!=null)
            {
                oldrole.RoleName = model.RoleName;
                oldrole.RolePid = model.RolePid;
                oldrole.RoleIsEnable = model.RoleIsEnable;
                oldrole.RoleModifyPeople = model.RoleModifyPeople;
                oldrole.RoleModifyTime = model.RoleModifyTime;
                return db.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
    }
}
