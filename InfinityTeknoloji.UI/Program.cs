using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using InfinityTeknoloji.DataAccess.Context;
using InfinityTeknoloji.DataAccess.Entities;
using InfintyTeknoloji.Business.Implementation;
using InfinityTeknoloji.UI.Middlewares;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("InfinityTeknolojiDbContextConnection") ?? throw new InvalidOperationException("Connection string 'InfinityTeknolojiDbContextConnection' not found.");

builder.Services.AddDbContext<InfinityTeknolojiDbContext>(options =>
    options.UseSqlServer(connectionString)); ;

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<InfinityTeknolojiDbContext>(); ;
builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ExamsManager>();
builder.Services.AddScoped<QuestionsManager>();
builder.Services.AddScoped<AnswerManager>();
builder.Services.AddScoped<CategoryManager>();


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
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

