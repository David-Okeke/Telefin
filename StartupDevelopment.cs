using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using EarlyMan.Models;

namespace EarlyMan
{
    public class StartupDevelopment
    {
        public StartupDevelopment(IConfiguration configuration) =>
        Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
            Configuration["Data:3dProdLocation:ConnectionString"]));
            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(Configuration["Data:EarlyManIdentity:ConnectionString"]));

            services.AddIdentity<AppUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;

                opts.Password.RequiredLength = 6;
                opts.Password.RequireDigit = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireDigit = false;
                opts.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IPromotionRepository, EFPromotionRepository>();

            services.ConfigureApplicationCookie(opts
                => opts.LoginPath = "/User/SignIn");

            services.AddTransient<IPrintRepository, EFPrintRepository>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            //  app.UseBrowserLink();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}