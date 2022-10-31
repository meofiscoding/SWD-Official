using App.DAL.DataContext;
using App.DAL.Repositories;
using App.DAL.Repositories.Contracts;
using App.BLL.Services;
using App.BLL.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using App.DAL.Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

builder.Services.AddSession();

builder.Services.AddDbContext<CMCContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CMC")));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Forbidden/";
    });

//Repository Provider (Regist repository)
builder.Services.AddTransient(typeof(IAccountRepository<>), typeof(AccountRepository<>));
builder.Services.AddTransient(typeof(ICardTemplateRepository<>), typeof(CardTemplateRepository<>));
//Service Provider (Regist Service)
builder.Services.AddScoped<ICardTemplateService, CardTemplateService>();
builder.Services.AddScoped<IAccountService, AccountService>();
var cookiePolicyOptions = new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
};
var app = builder.Build();
app.UseCookiePolicy(cookiePolicyOptions);
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    SeedData.Initialize(service);
}

app.UseSession();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
