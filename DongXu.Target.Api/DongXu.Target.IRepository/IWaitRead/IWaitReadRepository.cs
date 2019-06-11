using System;
using System.Collections.Generic;
using System.Text;

using DongXu.Target.Model;

namespace DongXu.Target.IRepository.IWaitRead
{
    public interface IWaitReadRepository
    {
        List<Attention> GetWaitReadList(int id);
    }
}
