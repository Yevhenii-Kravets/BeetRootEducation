using BuisnessLogic;
using BuisnessLogic.Interfaces;
using BuisnessLogic.Services;
using Calendar.Filters;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Models;
using Serilog;
using Serilog.Events;
using Task = Models.Task;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
            .CreateLogger();
        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);


        //builder.Services.AddControllersWithViews();

        builder.Services.AddControllersWithViews(options =>
        {
            options.Filters.Add<ExceptionFilter>();
        });

       
        builder.Services.AddScoped<IServiceItem<Task>, TaskService>();
        builder.Services.AddScoped<IServiceItem<Event>, EventService>();

        ConfigureServices(builder.Services, builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CalendarDbContext>(options =>
        {
            //options.UseInMemoryDatabase("CalendarDbContext");
            options.UseSqlServer("Server=localhost;" +
                "Database=FPCalendarDB;" +
                "TrustServerCertificate=True;" +
                "Integrated Security=true;" +
                "MultipleActiveResultSets=true;");
        });
    }
}