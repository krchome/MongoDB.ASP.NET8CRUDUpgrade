using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDb.ASP.NETCore3CRUDSample.DataAccess;
using MongoDb.ASP.NETCore3CRUDSample.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Access configuration settings
var configuration = builder.Configuration;

// Add services to the container
builder.Services.AddMvc();
builder.Services.Configure<Settings>(options =>
{
    options.ConnectionString = configuration.GetSection("MongoDB:ConnectionString").Value;
    options.Database = configuration.GetSection("MongoDB:Database").Value;
});
builder.Services.AddTransient<ICustomerContext, CustomerContext>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


//namespace MongoDb.ASP.NETCore3CRUDSample
//{
//    //public class Program
//    //{
//    //    public static void Main(string[] args)
//    //    {
//    //        CreateHostBuilder(args).Build().Run();
//    //    }

//    //    public static IHostBuilder CreateHostBuilder(string[] args) =>
//    //        Host.CreateDefaultBuilder(args)
//    //            .ConfigureWebHostDefaults(webBuilder =>
//    //            {
//    //                webBuilder.UseStartup<Startup>();
//    //            });
//    //}

//}
