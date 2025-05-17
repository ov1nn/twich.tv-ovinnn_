using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using twich.tv_ovinnn_.Data;

var builder = WebApplication.CreateBuilder(args);

// ���������� ������ ����������� �� appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ������������ DbContext � SQLite
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(connectionString));

// ��������� �������������� ������
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Signin/Index";       // ���� �������������� ���� �� ����������������
        options.AccessDeniedPath = "/Signin/AccessDenied"; // ���� ������ ��������
    });

// ������������ ����������� � ���������������
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// ������� ���� ������ ��� �������
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.EnsureCreated(); // ��� db.Database.Migrate() ���� ����������� ��������
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // ����������� ����� UseAuthorization()

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
