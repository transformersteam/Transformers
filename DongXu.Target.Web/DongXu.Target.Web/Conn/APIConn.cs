using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.Configuration;
namespace DongXu.Target.Web.Conn
{
   public class APIConn
    {
        public static string MyAPIConn = ConfigurationManager.Configuration.GetConnectionString("Connection");
    }
}
