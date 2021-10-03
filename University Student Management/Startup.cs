using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using StudentManagementBLL;
using StudentManagementBLL.ClassScheduleBLL;
/*using StudentManagementBLL.AccountServiceBLL;*/
using StudentManagementBLL.CourseAssignBLL;
using StudentManagementBLL.CourseBLL;
using StudentManagementBLL.CourseEnrollBLL;
using StudentManagementBLL.DayBLL;
using StudentManagementBLL.DeletedCourseAssignServiceBLL;
using StudentManagementBLL.DeletedRoomAllocationBLL;
using StudentManagementBLL.DepartmentBLL;
using StudentManagementBLL.DesignationBLL;
using StudentManagementBLL.GradeBLL;
using StudentManagementBLL.RoomAllocationBLL;
using StudentManagementBLL.RoomBLL;
using StudentManagementBLL.SemesterBLL;
using StudentManagementBLL.StudentBLL;
using StudentManagementBLL.StudentResultBLL;
using StudentManagementBLL.TeacherBLL;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Student_Management.Interfaces;
using University_Student_Management.services;

namespace University_Student_Management
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            /*Configuration = configuration;*/
            this._config = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 6;

            }
            );



            services.AddControllers();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "University_Student_Management", Version = "v1" });
            });

            //resolves camelcase problem & looping problem
            services.AddControllers().AddNewtonsoftJson(options =>
            {
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
            services.AddScoped<IDayBLL, DayBLL>();
            services.AddScoped<IRoomBLL, RoomBLL>();
            services.AddScoped<IGradeBLL, GradeBLL>();
            services.AddScoped<IDeletedRoomAllocationBLL, DeletedRoomAllocationBLL>();
            services.AddScoped<IClassScheduleBLL, ClassScheduleBLL>();
            /*services.AddScoped<IAccountServiceBLL, AccountServiceBLL>();*/
            services.AddScoped<ITokenService, TokenService>();


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
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
