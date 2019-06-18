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
        //添加人员
        public int AddUser(User model)
        {
            db.User.Add(model);
            db.SaveChanges();
            return model.UserId;
        }
        //添加人员 角色关联
        public int AddUserrole(int uid, int[] role)
        {
            List<Userrole> rplist = new List<Userrole>();
            for (int i = 0; i < role.Length; i++)
            {
                Userrole rp = new Userrole();
                rp.UserId = uid;
                rp.RoleId = role[i];
                rplist.Add(rp);
            }
            db.Userrole.AddRange(rplist);
            //db.Database.ExecuteSqlCommand("insert into rolepower(Role_Id,Power_Id) values(@RoleId,@RolePowerId)", rplist);
            return db.SaveChanges();
        }
        //删除人员
        public int DeleteUser(int userid)
        {
            User user = db.User.Where(u => u.UserId == userid).FirstOrDefault();
            db.User.Remove(user);
            //1.0 先按照条件查询
            var list = db.Userrole.Where(m => m.UserId == userid).ToList();
            //2.0 遍历集合，将 要删除的 对象 的代理对象的State 设置为 Deleted
            list.ForEach(u => db.Userrole.Remove(u));
            //3.0 执行更新
            int resCount = db.SaveChanges();

            return resCount;
        }
        //显示角色
        public List<Role> GetRoleList()
        {
            throw new NotImplementedException();
        }

        //显示人员
        public List<User> GetUserList()
        {
            List<User> userList = db.User.ToList();
            return userList;
        }
        //反填人员
        public User GetUserById(int userId)
        {
            User user = db.User.Where(m => m.UserId == userId).FirstOrDefault();
            return user;
        }
        //反填人员角色
        public List<Userrole> GetUserroleById(int userId)
        {
            List<Userrole> userrole = db.Userrole.Where(m => m.UserId == userId).ToList();
            return userrole;
        }
        //修改人员角色
        public int UpdateUser(User user, int[] role)
        {
            var tmpUser = db.User.Where(m => m.UserId == user.UserId).FirstOrDefault();
            if (tmpUser != null)
            {
                tmpUser.UserRealName = user.UserRealName;
                tmpUser.User_IdentityId = user.User_IdentityId;
                db.Database.ExecuteSqlCommand($"DELETE from Userrole where User_Id={user.UserId}");
                List<Userrole> rplist = new List<Userrole>();
                for (int i = 0; i < role.Length; i++)
                {
                    Userrole rp = new Userrole();
                    rp.UserId = user.UserId;
                    rp.RoleId = role[i];
                    rplist.Add(rp);
                }
                db.Userrole.AddRange(rplist);
                return db.SaveChanges();
            }
            return 0;
        }
    }
}
