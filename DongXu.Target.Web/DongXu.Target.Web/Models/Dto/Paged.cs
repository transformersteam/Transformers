using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DongXu.Target.Web
{
    public class Paged<T>
    {
        public int maxPage { get; set; }

        public int total { get; set; }

        public List<T> GetList { get; set; }
    }
}
