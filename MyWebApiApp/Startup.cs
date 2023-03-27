using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyWebApiApp.Data;
using MyWebApiApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApiApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // proxy Configuration tu dong map vao appsettings.json(dinh nghia cau hin config)
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // ConfigureServices khai bao service va dependence de su dung
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            // khai bap mott dependence tao luc connect voi SQL
            services.AddDbContext<MyDBContext>(option =>
            {
                // nhieu option
                option.UseSqlServer(Configuration.GetConnectionString("SampleDbContext"));
            });


           // services.AddScoped<ILoaiReponsitory, LoaiReponsitory>();
            services.AddScoped<ILoaiReponsitory, LoaiReponsitoryInMemmory>();
            services.AddScoped<IHangHoaResponsitory, HangHoaReponsitory>();


            var secretKey = Configuration["AppSettings:SecretKey"];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

            // add AddAuthentication()
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    // tu cap token 
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    // ky vao token
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                    ClockSkew = TimeSpan.Zero
                };
            });

            // AddSwaggerGen dinh nghia default tu luc tao source
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyWebApiApp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Configure mot so service muon call hoac goi thi goi trong function Configure
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyWebApiApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // cau hinh mac dinh va khong dinh nghia khac voi mvc
                endpoints.MapControllers();
            });
        }
    }
}
