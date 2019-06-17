using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.AspNetCore.Hosting;

namespace DongXu.Target.Web.Conn
{
   public class ConfigurationManager
    {
        public static IConfiguration Configuration { get; set; }
         static ConfigurationManager() 
        {
            //ReloadOnChange = true 当appsettings.json被修改时重新加载            
            Configuration = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();
        }
    }
}
