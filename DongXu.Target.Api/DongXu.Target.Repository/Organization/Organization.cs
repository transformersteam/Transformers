﻿using System;
using DongXu.Target.Model;
using DongXu.Target.IRepository.Organization;
using System.Collections.Generic;
using System.Linq;

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

        public List<Role> GetRolesOList(int Identify)
        {
            return db.Role.Where(m => m.RoleIdentify == Identify).ToList();
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
