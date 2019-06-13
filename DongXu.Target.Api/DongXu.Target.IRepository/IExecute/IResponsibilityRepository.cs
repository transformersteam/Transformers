using System;
using System.Collections.Generic;
using System.Text;
using DongXu.Target.Model;
using DongXu.Target.Model.Dto;

namespace DongXu.Target.IRepository.IExecute
{
    public interface IResponsibilityRepository
    {
        /// <summary>
        /// 待办事项集合
        /// </summary>
        /// <returns></returns>
        List<MainResponsibility> GetMainResponsibilityInfo();

        /// <summary>
        /// 待办事项显示
        /// </summary>
        /// <returns></returns>
        MainResponsibilityPageination GetMainResponsibilityList(int pageindex = 1, int pagesize = 3);
    } 
}
