using Microsoft.EntityFrameworkCore;
using ScientaScheduler.MVC.Data;
using ScientaScheduler.MVC.Models.MapingProfiles;

namespace ScientaScheduler.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<BloggieDbContext>(options=>
            {
                options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("LocalHost"));
            });

            builder.Services.AddAutoMapper(typeof(BlogProfile));

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}