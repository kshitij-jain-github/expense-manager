using ExpenseManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

IWebHostEnvironment _env = builder.Environment;

builder.Services.AddDbContext<ExpenseDbContext>(options =>
    options.UseSqlServer("Server = sql.bsite.net\\MSSQL2016;Database =expensemanager_;User ID=expensemanager_;Password=Jain1530@.com;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security = false;"));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ExpenseDbContext>();

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
app.UseAuthentication();    

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Expense}/{action=Index}/{id?}");


