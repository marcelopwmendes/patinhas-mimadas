using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PatinhasMimadas.Data;
using PatinhasMimadas.DataAccess;
using PatinhasMimadas.DataAccess.Interfaces;
using PatinhasMimadas.Services;
using PatinhasMimadas.Services.Interfaces;

namespace PatinhasMimadas.API
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
            services.AddControllers();
            services.AddTransient<IEmployeeRoleService, EmployeeRoleService>();
            services.AddTransient<IEmployeeRoleDataAccess, EmployeeRoleDataAccess>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeDataAccess, EmployeeDataAccess>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerDataAccess, CustomerDataAccess>();
            services.AddTransient<IServiceService, ServiceService>();
            services.AddTransient<IServiceDataAccess, ServiceDataAccess>();
            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<IBookingDataAccess, BookingDataAccess>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
