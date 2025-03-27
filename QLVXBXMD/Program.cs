using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QLVXBXMD.Models.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>() // Nếu cần Role
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
async Task CreateRoles(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

    string[] roleNames = { "Khách hàng", "Nhân viên", "Quản lý" };
    foreach (var roleName in roleNames)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    var adminEmail = "admin@gmail.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        var newAdmin = new AppUser
        {
            UserName = "admin",
            Email = adminEmail,
            FullName = "Quản Lý Hệ Thống",
            SDT = "0898133460",
            CCCD = "123456789012",
            EmailConfirmed = true
        };

        var createAdmin = await userManager.CreateAsync(newAdmin, "Admin@123");
        if (createAdmin.Succeeded)
        {
            await userManager.AddToRoleAsync(newAdmin, "Quản lý");
            Console.WriteLine("Tạo tài khoản Admin thành công.");
        }
        else
        {
            Console.WriteLine($"Tạo tài khoản Admin thất bại: {string.Join(", ", createAdmin.Errors.Select(e => e.Description))}");
            return;
        }
    }
    else
    {
        // Đặt lại mật khẩu cho tài khoản đã tồn tại
        var token = await userManager.GeneratePasswordResetTokenAsync(adminUser);
        var resetResult = await userManager.ResetPasswordAsync(adminUser, token, "Admin@123");
        if (resetResult.Succeeded)
        {
            Console.WriteLine("Đặt lại mật khẩu Admin thành công.");
        }
        else
        {
            Console.WriteLine($"Đặt lại mật khẩu thất bại: {string.Join(", ", resetResult.Errors.Select(e => e.Description))}");
            return;
        }

        // Đảm bảo tài khoản không bị khóa
        if (await userManager.IsLockedOutAsync(adminUser))
        {
            await userManager.SetLockoutEndDateAsync(adminUser, null);
            await userManager.ResetAccessFailedCountAsync(adminUser);
            Console.WriteLine("Đã mở khóa tài khoản Admin.");
        }
    }
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await CreateRoles(services);
}
app.Run();
