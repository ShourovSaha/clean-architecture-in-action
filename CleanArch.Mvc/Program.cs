using CleanArch.Data.Context;
using CleanArch.Infra.IoC;
using CleanArch.Mvc.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;

namespace CleanArch.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            registerServices(builder.Services, builder.Configuration);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("VarsityIdentityDBConnStr")
                    ?? throw new InvalidOperationException("Connection string 'VarsityIdentityDBConnStr' not found."))
            );

            builder.Services.AddDbContext<VarsityDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("VarsityDBConnStr")
                    ?? throw new InvalidOperationException("Connection string 'VarsityDBConnStr' not found."))
            );

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }

        private static void registerServices(IServiceCollection services, IConfiguration configuration)
        {
            DependencyContainer.RegisterDepandancy(services, configuration);
        }
    }
}