using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using testlog.Models;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("databaseConnection") ?? throw new InvalidOperationException("Connection string 'databaseConnection' not found.");

string con = """"
    Data Source=DESKTOP-UV5VU0D\SQLEXPRESS;
    Initial Catalog=testlog;
    Integrated Security=True;
    Pooling=False;
    Encrypt=True;
    Trust Server Certificate=True
    """";

builder.Services.AddDbContext<database>(options => options.UseSqlServer(con));

builder.Services.AddDefaultIdentity<iuser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<database>();




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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
