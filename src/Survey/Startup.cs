using Invoice.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Survey.Core.Interfaces.Infastructure;
using Survey.Core.Interfaces.Services;
using Survey.Data.AppContext;
using Survey.Data.Infastructure;
using Survey.Services;
using Survey.Web.Infrastructure;
using Survey.Web.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Survey
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
            services.AddDbContext<SurveyDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SurveyDBConnection")));

            services.AddControllersWithViews();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ISurveyService, SurveyService>();

            services.AddScoped<IResourceHandler, ResourceHandler>();
            
            services.AddAutoMapper(typeof(AutoMapperProfile));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            ConfigureLocalization(app);

            app.UseMiddleware(typeof(ErrorHandling));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }


        private void ConfigureLocalization(IApplicationBuilder app)
        {
            var supportedCultures = new[]
            {
                new CultureInfo(SupportedLanguage.ar),
                new CultureInfo(SupportedLanguage.en)
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(SupportedLanguage.ar),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
            });
        }
    }
}
