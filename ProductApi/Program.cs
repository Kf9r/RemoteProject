using Microsoft.EntityFrameworkCore;
using ProductApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Добавляем DbContext для SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавляем контроллеры
builder.Services.AddControllers();

// Настраиваем Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "MaterialsApi", Version = "v1" });
});

// Настройка CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()    // Разрешаем запросы с любых источников
              .AllowAnyMethod()    // Разрешаем все HTTP-методы (GET, POST, PUT и т.д.)
              .AllowAnyHeader();   // Разрешаем все заголовки
    });
});

var app = builder.Build();

// Конфигурируем pipeline запросов
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Включение CORS (должно быть после UseRouting и перед UseAuthorization)
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();

app.Run();