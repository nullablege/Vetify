using BL;
using BL.Abstract;
using BL.Concrete;
using DAL;
using DAL.Abstract;
using DAL.Concrete;
using EL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vetify.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddIdentity<Kullanici, IdentityRole<int>>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;

    options.User.RequireUniqueEmail = true; 


    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<Context>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<IUserClaimsPrincipalFactory<Kullanici>, CustomUserClaimsPrincipalFactory>();




builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied"; // Yetkisiz eri�im sayfas�
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(30); // Oturumun ne kadar a��k kalaca��
    options.Cookie.HttpOnly = true;
    options.Cookie.Name = "Vetify.AuthCookie";
});


//builder.Services.AddScoped<IKullaniciDal, EfKullaniciDal>();
builder.Services.AddScoped<IHayvanDal, EfHayvanDal>();
builder.Services.AddScoped<IFaturaDal, EfFaturaDal>();
builder.Services.AddScoped<IOdemeDal, EfOdemeDal>();
builder.Services.AddScoped<IRandevuDal, EfRandevuDal>();
builder.Services.AddScoped<ISaglikKaydiDal, EfSaglikKaydiDal>();
builder.Services.AddScoped<ITedaviDal, EfTedaviDal>();

//builder.Services.AddScoped<IKullaniciService, KullaniciManager>();
builder.Services.AddScoped<IHayvanService, HayvanManager>();
builder.Services.AddScoped<IFaturaService, FaturaManager>();
builder.Services.AddScoped<IOdemeService, OdemeManager>();
builder.Services.AddScoped<IRandevuService, RandevuManager>();
builder.Services.AddScoped<ISaglikKaydiService, SaglikKaydiManager>();
builder.Services.AddScoped<ITedaviService, TedaviManager>();



var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // RoleManager
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();
        var userManager = services.GetRequiredService<UserManager<Kullanici>>();

        // Roller
        string[] roleNames = { "Admin", "Customer" };

        foreach (var roleName in roleNames)
        {
            // Rol veritaban�nda var m� ?
            var roleExists = await roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                // Rol yoksa olu�ur
                await roleManager.CreateAsync(new IdentityRole<int>(roleName));
            }
        }

        
        var adminEmail = "admin@admin.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        
        if (adminUser == null)
        {
            var admin = new Kullanici
            {
                AdSoyad = "Admin",
                Email = adminEmail,
                UserName = adminEmail,
                OlusturmaTarihi = DateTime.Now,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(admin, "admin123");
            
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
    catch (Exception ex)
    {
        // Hata logla
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Roller olu�turulurken bir hata olu�tu.");
    }
}


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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
