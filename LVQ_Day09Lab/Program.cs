using Microsoft.EntityFrameworkCore;
using Lvq_Day09Lab.Models;

var builder = WebApplication.CreateBuilder(args);

// ====================
// Add services to the container.
// ====================

// ✅ Dòng này rất quan trọng: thêm MVC Controllers + Views
builder.Services.AddControllersWithViews();

// ✅ Kết nối Database (sử dụng DbContext)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Thêm xác thực và phân quyền (nếu dùng [Authorize])
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

// ====================
// Configure the HTTP request pipeline.
// ====================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ✅ Middleware xác thực và phân quyền
app.UseAuthentication();
app.UseAuthorization();

// ✅ Định tuyến mặc định
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
