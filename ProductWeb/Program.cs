using ProductWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы в контейнер
builder.Services.AddRazorPages();
builder.Services.AddHttpClient<ApiService>(); // Регистрация сервиса для работы с API

var app = builder.Build();

// Настройка конвейера HTTP-запросов
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // Стандартное значение HSTS - 30 дней
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Поддержка статических файлов (wwwroot)

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();