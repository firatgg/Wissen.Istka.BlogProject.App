using Microsoft.EntityFrameworkCore;
using Wissen.Istka.BlogProject.App.DataAccess.Contexts;
using Wissen.Istka.BlogProject.App.Service.Extensions;

namespace Wissen.Istka.BlogProject.App.WebMvcUI
{
    public class Program
    {
        public static void Main(string[] args)
        {

           

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));
            builder.Services.AddExtensions();



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

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
