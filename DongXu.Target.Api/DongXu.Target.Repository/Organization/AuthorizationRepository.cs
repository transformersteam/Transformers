using System;
using System.Collections.Generic;
using System.Text;

using DongXu.Target.Model;
using System.Linq;
using DongXu.Target.IRepository.IOrganization;
using DongXu.Target.Model.Dto;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Data;

namespace DongXu.Target.Repository.Organization
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        dxdatabaseContext db = new dxdatabaseContext();
        public int AddUser(User model)
        {
            throw new NotImplementedException();
        }

        public int AddUserrole(int uid, int[] role)
        {
            throw new NotImplementedException();
        }

        public int DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetRoleList()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public List<Userrole> GetUserroleById(int userId)
        {
            throw new NotImplementedException();
        }
        //修改人员角色
        public int UpdateUser(User model, int[] role)
        {
            var user = db.User.Where(m => m.UserId == model.UserId).FirstOrDefault();
            if (user != null)
            {
                //user.RoleName = model.RoleName;
                //user.RoleContent = model.RoleContent;
                //role.RolePid = model.RolePid;
                //role.RoleModifyPeople = model.RoleModifyPeople;
                //role.RoleModifyTime = model.RoleModifyTime;
                //db.Database.ExecuteSqlCommand($"DELETE from rolepower where Role_Id={model.RoleId}");
                //List<Rolepower> rplist = new List<Rolepower>();
                //for (int i = 0; i < power.Length; i++)
                //{
                //    Rolepower rp = new Rolepower();
                //    rp.RoleId = model.RoleId;
                //    rp.PowerId = power[i];
                //    rplist.Add(rp);
                //}
                //db.Rolepower.AddRange(rplist);
                return db.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
    }
}
