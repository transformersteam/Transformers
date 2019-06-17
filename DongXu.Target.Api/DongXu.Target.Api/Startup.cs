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
using DongXu.Target.IRepository.IExecute;

using DongXu.Target.Repository;
using DongXu.Target.IRepository.IOrganization;
using DongXu.Target.IRepository.IWaitRead;
using DongXu.Target.Repository.WaitReadRepository;
using DongXu.Target.Repository.Execute;
using Swashbuckle.AspNetCore.Swagger;
using DongXu.Target.IRepository.IGoalManage;
using DongXu.Target.Repository.GoalManage;
using DongXu.Target.Repository.Company;
using DongXu.Target.IRepository.ICompany;

namespace DongXu.Target.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /**
 *                             _ooOoo_
 *                            o8888888o
 *                            88" . "88
 *                            (| -_- |)
 *                            O\  =  /O
 *                         ____/`---'\____
 *                       .'  \\|     |//  `.
 *                      /  \\|||  :  |||//  \
 *                     /  _||||| -:- |||||-  \
 *                     |   | \\\  -  /// |   |
 *                     | \_|  ''\---/''  |   |
 *                     \  .-\__  `-`  ___/-. /
 *                   ___`. .'  /--.--\  `. . __
 *                ."" '<  `.___\_<|>_/___.'  >'"".
 *               | | :  `- \`.;`\ _ /`;.`/ - ` : | |
 *               \  \ `-.   \_ __\ /__ _/   .-` /  /
 *          ======`-.____`-.___\_____/___.-`____.-'======
 *                             `=---='
 *          ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
 *                     佛祖保佑        永无BUG
*/

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //ef mysql 配置
            services.AddDbContext<dxdatabaseContext>(options => options.UseMySql(Configuration.GetConnectionString("MySqlConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //OpenAPI注册
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            // 注册接口和实现类的映射关系 
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IWaitReadRepository, WaitReadRepository>();
            services.AddScoped<IGoalRepository, GoalRepository>();
            services.AddScoped<IResponsibilityRepository,ResponsibilityRepository>();
            services.AddScoped<IIntegralRepository, IntegralRepository>();
            services.AddScoped<IGoalManageRepository, GoalManageRepository>();

            services.AddScoped<ITargetRepository, TargetRepository>();

            services.AddScoped<ICompanyIntegralRepository, CompanyIntegralRepository>(); 


            //注册跨域服务，允许所有来源
            services.AddCors(options =>
                options.AddPolicy("AllowAnyCors",
                p => p.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().AllowCredentials().AllowAnyOrigin())
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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            //允许跨域访问
            app.UseCors("AllowAnyCors");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}



