using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DongXu.Target.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DongXu.Target.IRepository;
using DongXu.Target.Repository;
using DongXu.Target.IRepository.IOrganization;
using DongXu.Target.IRepository.IWaitRead;
using DongXu.Target.Repository.WaitReadRepository;

namespace DongXu.Target.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //ef mysql 配置
            services.AddDbContext<dxdatabaseContext>(options => options.UseMySql(Configuration.GetConnectionString("MySqlConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // 注册接口和实现类的映射关系 
            services.AddScoped<IOrganization, Organization>();
            services.AddScoped<IWaitReadRepository, WaitReadRepository>();

            //注册跨域服务，允许所有来源
            services.AddCors(options =>
                options.AddPolicy("AllowAnyCors",
                p => p.AllowAnyOrigin())
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //允许跨域访问
            app.UseCors("AllowAnyCors");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
