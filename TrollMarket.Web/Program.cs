using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Identity.Client;
using TrollMarket.Provider;
using TrollMarket.Provider.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IAccountProvider, AccountProvider>();


//middle-wares
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllersWithViews().AddNewtonsoftJson();
object value = builder.Services.AddRazorPages().AddNewtonsoftJson();


builder.Services.AddAntiforgery(option => option.HeaderName = "__RequestVerificationToken");

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                         .AddCookie(a =>
                         {
                             a.LoginPath = "/Account/Login";
                             a.AccessDeniedPath = "/Account/LoginFailed";
                         });

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
