using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

    // ----------------------------------------------------------------------------------------
    builder.Services.AddDbContext<Context>();
    builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

    builder.Services.AddHttpClient();

    // Mapper için tanımladık
    builder.Services.AddAutoMapper(typeof(Program));

    // Proje seviyesinde Authorize için 2.adım
    builder.Services.AddMvc(config => 
    {
        var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
        config.Filters.Add(new AuthorizeFilter(policy));
    });
    builder.Services.ConfigureApplicationCookie(options => 
    {
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(10); // Oturum süresi
        options.LoginPath = "/User/UserLogin/";
    });
    // ----------------------------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

    app.UseStatusCodePagesWithReExecute("/Error/Error404", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

    // Proje seviyesinde Authorize için 1.adım
    app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
