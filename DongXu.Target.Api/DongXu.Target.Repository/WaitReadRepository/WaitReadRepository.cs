using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DongXu.Target.IRepository.IWaitRead;
using DongXu.Target.Model;
using Microsoft.EntityFrameworkCore;

namespace DongXu.Target.Repository.WaitReadRepository
{
    public class WaitReadRepository : IWaitReadRepository
    {
        /// <summary>
        /// 根据登录人的id查询待办列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Attention> GetWaitReadList(int id)
        {
            using (dxdatabaseContext context = new dxdatabaseContext())
            {
                var list = context.Attention.Include("Goal").Where(m => m.UserId == id).ToList();
                return list;
            }
        }
    }
}
