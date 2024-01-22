using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication2.Data;
using WebApplication2.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

string hangfireConnectionString = builder.Configuration.GetConnectionString("HangfireConnection") 
    ?? throw new InvalidOperationException("Connection string 'HangfireConnection' not found.");
builder.Services.AddHangfire(configuration => configuration
    .UseSqlServerStorage(hangfireConnectionString));


builder.Services.AddDbContext<WebApplication2Cddontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplication2Cddontext") 
        ?? throw new InvalidOperationException("Connection string 'WebApplication2Cddontext' not found.")));

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<EmailService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseHangfireDashboard();
app.UseHangfireServer();

//RecurringJob.AddOrUpdate(() => Console.WriteLine("Este trabajo se ejecutará periódicamente"), Cron.Minutely);

app.Run();
