using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ImportXmlToJson.Data;
using ImportXmlToJson.Models;
using ImportXmlToJson.Domain;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ImportXmlToJsonContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ImportXmlToJsonContext") ?? throw new InvalidOperationException("Connection string 'ImportXmlToJsonContext' not found.")));

builder.Services.AddTransient<ContractsRepository>();
builder.Services.AddTransient<ImportsRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Contracts}/{action=Index}/{id?}");

app.Run();
