using System;
using System.Collections.Generic;
using System.Text;

namespace DongXu.Target.Web
{
    /// <summary>
    /// 分页泛型类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageData<T>
    {
        public List<T> GetData { get; set; }

        public int TotalCount { get; set; }
    }
}
