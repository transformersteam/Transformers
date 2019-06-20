using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Model.Dto
{
    public class PageData<T>
    {
        public List<T> GetData { get; set; }

        public int TotalCount { get; set; }
    }
}
