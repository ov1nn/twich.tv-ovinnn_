using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using twich.tv_ovinnn_.Data;

var builder = WebApplication.CreateBuilder(args);

// Подключаем строку подключения из appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Регистрируем DbContext с SQLite
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(connectionString));

// Добавляем аутентификацию куками
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Signin/Index";       // куда перенаправлять если не аутентифицирован
        options.AccessDeniedPath = "/Signin/AccessDenied"; // если доступ запрещен
    });

// Регистрируем контроллеры с представлениями
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Создаем базу данных при запуске
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.EnsureCreated(); // или db.Database.Migrate() если используешь миграции
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // обязательно перед UseAuthorization()

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
