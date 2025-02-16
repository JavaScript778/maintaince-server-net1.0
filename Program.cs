using maintaince_server_net.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Session;
var builder = WebApplication.CreateBuilder(args);


// ��� Session ֧��
builder.Services.AddDistributedMemoryCache();  // ʹ���ڴ滺��
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(365);  // ���� Session �����ڣ�365 �죩
});

// ������ݿ�������
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(10, 5, 12)) // �汾�Ÿ���������ݿ����
    )
);

// ���Razor Pages��API������
builder.Services.AddRazorPages();
builder.Services.AddControllers();

var app = builder.Build();
// ���� Session �м��
app.UseSession();
//// Ĭ��·����ת�� /Login ҳ��
//app.MapGet("/", context =>
//{
//    context.Response.Redirect("/Login"); // Ĭ����ת����¼ҳ��
//    return Task.CompletedTask;
//});
// �����쳣�����HSTS��ֻ�ڷǿ��������У�
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();



// ӳ��Razor Pages��API������
app.MapRazorPages();
app.MapControllers(); // ����API·��

app.Run();
