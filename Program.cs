using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Acesvv.Data;
using Acesvv.Areas.Identity.Data;
using Acesv2.Models;
using System.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;
using Acesvv.Models;
using Microsoft.AspNetCore.Authorization;
using Acesvv;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AcesvvContextConnection") ?? throw new InvalidOperationException("Connection string 'AcesvvContextConnection' not found.");

builder.Services.AddDbContext<AcesvvContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<UsuarioModel>(options => options.SignIn.RequireConfirmedAccount = false)
.AddEntityFrameworkStores<AcesvvContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BD>();




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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
