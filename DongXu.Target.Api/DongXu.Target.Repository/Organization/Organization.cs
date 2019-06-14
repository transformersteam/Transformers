﻿using DongXu.Target.Model;
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
            db.SaveChanges();
            return model.RoleId;
        }


        public int DeleteRolesO(int id)
        {
            var roleo = db.Role.Where(m => m.RoleId == id).FirstOrDefault();
            db.Role.Remove(roleo);
            //1.0 先按照条件查询
            var list = db.Role.Where(m => m.RolePid == id).ToList();
            //2.0 遍历集合，将 要删除的 对象 的代理对象的State 设置为 Deleted
            list.ForEach(u => db.Role.Remove(u));
            //3.0 执行更新
            int resCount = db.SaveChanges();

            return resCount;
        }


        public Role GetRolesById(int id)
        {
            return db.Role.Where(m => m.RoleId == id).FirstOrDefault();
        }

        public List<Role> GetRolesOList()
        {
            List<Role> list= db.Role.Where(m => m.RoleIdentify <3).ToList();
            return list;
        }

        public Role GetRolesOListById(int RoleId)
        {
            Role list = db.Role.Where(m => m.RoleIdentify != 3 && m.RoleId==RoleId).FirstOrDefault();
            return list;
        }

        public int UpdateRolesO(Role model)
        {
            var oldrole = db.Role.Where(m => m.RoleId == model.RoleId).FirstOrDefault();
            if(oldrole!=null)
            {
                oldrole.RoleName = model.RoleName;
                oldrole.RoleIdentify = model.RoleIdentify;
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
        public int UpdateRolesOName(Role model)
        {
            var oldrole = db.Role.Where(m => m.RoleId == model.RoleId).FirstOrDefault();
            if (oldrole != null)
            {
                oldrole.RoleName = model.RoleName;
                oldrole.RoleModifyPeople = model.RoleModifyPeople;
                oldrole.RoleModifyTime = model.RoleModifyTime;
                return db.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 角色
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRolesRList()
        {
            List<Role> list = db.Role.Where(m => m.RoleIdentify < 3).ToList();
            return list;
        }
    }
}
