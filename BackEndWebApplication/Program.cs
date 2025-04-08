using BackEndWebApplication.Data;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://mv-project-front-end-application.vercel.app") // Разрешаем доступ с фронтенда
              .AllowAnyHeader()  // Разрешаем все заголовки
              .AllowAnyMethod()  // Разрешаем все HTTP методы
              .AllowCredentials();  // Разрешаем отправку куки и авторизацию (если нужно)
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
