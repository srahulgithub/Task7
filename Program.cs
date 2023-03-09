using Assignment7;
using Assignment7.Models;
using Assignment7.Services;
using Autofac.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/build";
});


builder.Services.Configure<UserSettings>(
   builder.Configuration.GetSection("UserDatabase"));
builder.Services.AddSingleton<UserService>();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSpaStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});
app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";

    if (app.Environment.IsDevelopment())
    {
        spa.UseReactDevelopmentServer(npmScript: "start");
    }
});
app.Run();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
  //  app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
//}


//var startup = new Startup(builder.Configuration);

//startup.ConfigureServices(builder.Services);

//var app = builder.Build();

//startup.Configure(app, app.Environment);


//app.Run();

//namespace Assignment7
//{
  //  public class Program
    //{
      //  public static void Main(string[] args)
        //{
          //  CreateHostBuilder(args).Build().Run();
            

        //}

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
          //  Host.CreateDefaultBuilder(args)
            //    .ConfigureWebHostDefaults(webBuilder =>
              //  {
                //    webBuilder.UseStartup<Startup>();
                //});
        
  //  }

//}

