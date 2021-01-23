using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservices_jwt_Search.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microservices_jwt_Search.Service;
using Microservices_jwt_Search.Models;

namespace Microservices_jwt_Search
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
            
            // for any other (micro)service added to the searchDBcontext
            // the Dbcontext and the scoped should be registered with the constr
            services.AddDbContext<StudentSearchDBContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("StudentsDB")));
            services.AddScoped<ISearch<Student>, StudentSearchRepository>();
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
