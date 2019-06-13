using DongXu.Target.Model;
using System;
using System.Collections.Generic;
using System.Text;

using DongXu.Target.Model.Dto;

namespace DongXu.Target.IRepository
{
   public  interface ILoginRepository
    {
        User Login(string UserName, string UserPass); 
        List<UserQuery> GetPower(int UserId);  
    }
}
