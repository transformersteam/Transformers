using System;
using System.Collections.Generic;
using System.Text;

using DongXu.Target.IRepository;
using DongXu.Target.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DongXu.Target.Model.Dto;

namespace DongXu.Target.Repository
{
   public class LoginRepository : ILoginRepository
    {
        dxdatabaseContext Context = new dxdatabaseContext();

        public List<UserQuery> GetPower(int UserId)
        {
         var query=   Context.UserQuery.FromSql("select power.Power_Id,power.Power_Name,power.Power_Url,power.Power_PId,power.Power_SortId,power.Power_IsEnable from power " +
                "join rolepower on power.Power_Id = rolepower.Power_Id " +
                "join role on rolepower.Role_Id = role.Role_Id " +
                "join userrole on role.Role_Id = userrole.Role_Id " +
                "join user on userrole.User_Id = user.User_Id where  user.User_Id={0}",UserId).ToList();
            return query;
        }

        public User Login(string UserName, string UserPass)
        {
            var query = Context.User.Where(u => u.UserName == UserName).Where(u => u.UserPass == UserPass).FirstOrDefault();
            return query;
        }
    }
}
