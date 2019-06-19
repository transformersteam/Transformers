using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Model.Dto
{
   public class TargetTrack
    {
        /// <summary>
        /// 集团Id
        /// </summary>
        public int Role_Id { get; set; }

        /// <summary>
        /// 集团名称
        /// </summary>
        public string Role_Name { get; set; }

        /// <summary>
        /// 集团已完成目标数量
        /// </summary>
        public int Done { get; set; } 

        /// <summary>
        /// 集团总目标数量
        /// </summary>
        public int Num { get; set; } 

        /// <summary>
        /// 所占百分比
        /// </summary>
        public Decimal Percentage { get; set; } 
    }
}
