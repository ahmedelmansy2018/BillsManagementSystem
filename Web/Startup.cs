using Business_Logic_layer.Service;
using Business_Objects;
using Business_Objects.Interfaces;
using Business_Objects.Interfaces.Services;
using Data_Access_layer;
using Data_Access_layer.Repository;
using Data_Access_layer.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using DevExpress.AspNetCore;

namespace Web
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
            // services.AddRazorPages().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddControllersWithViews();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("BillsManagementDB"));
            });

            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped(typeof(IWorkService<>), typeof(WorkService<>));
            services.AddScoped<IReposCaseHeader, ReposCaseHeader>();
            services.AddDevExpressControls();




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
            app.UseStaticFiles(new StaticFileOptions
            {

                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules")),

                RequestPath = "/node_modules"

            });
            app.UseDevExpressControls();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //});
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "defaultRoute",
                    "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
