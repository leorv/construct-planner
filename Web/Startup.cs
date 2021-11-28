using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
using Repository.Interfaces;


namespace Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            string connectionString = Configuration.GetConnectionString("MySqlConnection");

            services.AddDbContext<ConstructContext>(options =>
                options.UseMySql(connectionString,
                    ServerVersion.AutoDetect(connectionString),
                    m => m.MigrationsAssembly("Repository")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllersWithViews();
                //.AddNewtonsoftJson(options =>
                //    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
                //        .Json.ReferenceLoopHandling.Ignore);
            services.AddRazorPages();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            // Caso não usássemos a unit of work, teríamos que implementar
            // AddScooped para todas as nossas interfaces.

            // Em produ��o, os arquivos Angular v�o ser servidos por este diret�rio:
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");

                    /* === outra maneira de iniciar ===
                    *
                    * spa.UseProxyToSpaDevelopmentServer("http://localhost:4200/");
                    *
                    */
                }
            });
        }
    }
}
