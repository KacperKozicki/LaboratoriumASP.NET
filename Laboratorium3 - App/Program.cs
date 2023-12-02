using Data;
using Laboratorium3___App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;

namespace Laboratorium3___App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRazorPages();//
            builder.Services.AddControllersWithViews();//

            builder.Services.AddTransient<IContactService, EFContactService>();

            builder.Services.AddDefaultIdentity<IdentityUser>()       // dodać
                .AddEntityFrameworkStores<Data.AppDbContext>();

            builder.Services.AddTransient<IAlbumService, EFAlbumService>();
            builder.Services.AddTransient<IPlaylistService, EFPlaylistService>();

            builder.Services.AddDbContext<AppDbContext>();

            

            builder.Services.AddSingleton<IDateTimeProvider, CurrentDateTimeProvider>();



            builder.Services.AddMemoryCache();                        // dodać
            builder.Services.AddSession();

            //builder.Services.AddSingleton<IContactService, MemoryContactService>();
            //builder.Services.AddSingleton<IAlbumService, MemoryAlbumService>();


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

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}