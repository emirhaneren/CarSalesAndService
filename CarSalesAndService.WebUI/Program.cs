using CarSalesAndService.Data;
using CarSalesAndService.Service.Abstract;
using CarSalesAndService.Service.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Servislerin eklenmesi
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));
builder.Services.AddTransient<ICarService, CarService>();
//Authentication Ayarlarý
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Account/Login"; //Login Path
    x.AccessDeniedPath = "/AccessDenied"; //Baþarýsýz Giriþteki Path
    x.LogoutPath = "/Account/Logout"; //Logout Path
    x.Cookie.Name = "Admin"; //Cookie Name
    x.Cookie.MaxAge = TimeSpan.FromDays(7); //Giriþ Sonrasý süresi
    x.Cookie.IsEssential = true;
});

builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminPolicy", policy => policy.RequireClaim("Role", "Admin"));
    x.AddPolicy("UserPolicy", policy => policy.RequireClaim("Role", "Admin", "User"));
    x.AddPolicy("CustomerPolicy", policy => policy.RequireClaim("Role", "Admin", "User", "Customer"));
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
            name: "adminPanel",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
