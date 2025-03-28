using DruckEmployeeMvc.Data;
using DruckEmployeeMvc.Repositories;
using DruckEmployeeMvc.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DruckEmployeeMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<EmplyeeDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DruckConnection"));
            });

            builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();

            builder.Services.AddControllersWithViews()
                            .AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled = true);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
