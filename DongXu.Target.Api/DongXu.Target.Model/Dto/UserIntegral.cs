using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Model.Dto
{
    /// <summary>
    /// 用户积分列表
    /// </summary>
    public class UserIntegral
    {
        public int User_Id { get; set; }

        public string User_Name { get; set; }

        public int Integral_Num { get; set; }
    }
}
