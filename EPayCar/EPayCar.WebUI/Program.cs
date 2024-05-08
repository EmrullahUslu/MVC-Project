using EPayCar.Core.Service;
using EPayCar.Model.Context;
using EPayCar.Service.DbService;
using Microsoft.EntityFrameworkCore;

namespace EPayCar.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddMvc();


            builder.Services.AddDbContext<EPayCarContext>(options => options.UseSqlServer("Server=USLU\\SQLEXPRESS;Database=EPayCar;TrustServerCertificate=True;Integrated Security=true;"));

            builder.Services.AddScoped(typeof(IDbService<>), typeof(CoreDbService<>));

            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "Admin/{Controller=Home}/{Action=Index}/{id?}"
            );

            app.MapControllerRoute(
             name: "default",
             pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}