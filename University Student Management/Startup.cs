using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using StudentManagementBLL;
using StudentManagementBLL.CourseAssignBLL;
using StudentManagementBLL.CourseBLL;
using StudentManagementBLL.CourseEnrollBLL;
using StudentManagementBLL.DeletedCourseAssignServiceBLL;
using StudentManagementBLL.DepartmentBLL;
using StudentManagementBLL.DesignationBLL;
using StudentManagementBLL.RoomAllocationBLL;
using StudentManagementBLL.SemesterBLL;
using StudentManagementBLL.StudentBLL;
using StudentManagementBLL.StudentResultBLL;
using StudentManagementBLL.TeacherBLL;
using StudentManagementDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Student_Management
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
                
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "University_Student_Management", Version = "v1" });
            });

            //resolves camelcase problem & looping problem
            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddScoped<ApplicationDbContext>();
          
            services.AddScoped<IDepartmentServiceBLL, DepartmentServiceBLL>();
            services.AddScoped<ITeacherServiceBLL, TeacherServiceBLL>();
            services.AddScoped<ICourseServiceBLL, CourseServiceBLL>();
            services.AddScoped<IDesignationServiceBLL, DesignationServiceBLL>();
            services.AddScoped<IStudentServiceBLL, StudentServiceBLL>();
            services.AddScoped<ICourseAssignServiceBLL, CourseAssignServiceBLL>();
            services.AddScoped<ICourseEnrollBLL, CourseEnrollBLL>();
            services.AddScoped<IStudentResultBLL, StudentResultBLL>();
            services.AddScoped<IDeletedCourseAssignBLL, DeletedCourseAssignBLL>();

            services.AddScoped<ISemesterServiceBLL, SemesterServiceBLL>();
            services.AddScoped<IRoomAllocationBLL, RoomAllocationBLL>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }*/
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "University_Student_Management v1"));
            }

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200")
                             .AllowAnyMethod()
                             .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
