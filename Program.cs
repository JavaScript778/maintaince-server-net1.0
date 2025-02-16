using maintaince_server_net.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Session;
var builder = WebApplication.CreateBuilder(args);


// 添加 Session 支持
builder.Services.AddDistributedMemoryCache();  // 使用内存缓存
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(365);  // 设置 Session 不过期（365 天）
});

// 添加数据库上下文
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(10, 5, 12)) // 版本号根据你的数据库调整
    )
);

// 添加Razor Pages和API控制器
builder.Services.AddRazorPages();
builder.Services.AddControllers();

var app = builder.Build();
// 启用 Session 中间件
app.UseSession();
//// 默认路由跳转到 /Login 页面
//app.MapGet("/", context =>
//{
//    context.Response.Redirect("/Login"); // 默认跳转到登录页面
//    return Task.CompletedTask;
//});
// 启用异常处理和HSTS（只在非开发环境中）
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();



// 映射Razor Pages和API控制器
app.MapRazorPages();
app.MapControllers(); // 启用API路由

app.Run();
