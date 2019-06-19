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
        /// <summary>
        /// 添加人员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddUser(User model)
        {
            db.User.Add(model);
            db.SaveChanges();
            return model.UserId;
        }

        /// <summary>
        /// 添加人员 角色关联
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="role"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// 删除人员
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// 显示角色
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRoleList()
        {
            throw new NotImplementedException();
        }

        
        /// <summary>
        /// 显示人员
        /// </summary>
        /// <returns></returns>
        public List<User> GetUserList()
        {
            List<User> userList = db.User.ToList();
            return userList;
        }
        
        /// <summary>
        /// 反填人员
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUserById(int userId)
        {
            User user = db.User.Where(m => m.UserId == userId).FirstOrDefault();
            return user;
        }
        
        /// <summary>
        /// 反填人员角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Userrole> GetUserroleById(int userId)
        {
            List<Userrole> userrole = db.Userrole.Where(m => m.UserId == userId).ToList();
            return userrole;
        }

        /// <summary>
        /// 修改人员角色
        /// </summary>
        /// <param name="user"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public int UpdateUser(User user, int[] role)
        {
            var tmpUser = db.User.Where(m => m.UserId == user.UserId).FirstOrDefault();
            if (tmpUser != null)
            {
                tmpUser.UserRealName = user.UserRealName;
                tmpUser.User_IdentityId = user.User_IdentityId;
                tmpUser.UserRoleName = user.UserRoleName;
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
