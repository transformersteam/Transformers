using System;
using System.Collections.Generic;
using System.Text;

using DongXu.Target.Model;
using DongXu.Target.Model.Dto;
namespace DongXu.Target.IRepository
{
    public interface IAuditRepository
    {
        AuditDto GetAuditDtoList(int userId,int goalId);
    }
}
