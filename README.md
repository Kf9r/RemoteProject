# RemoteProject

Проект демонстрирует интеграцию ASP.NET Core Web API с MS SQL Server и клиентским веб-приложением.

## 📦 Технологии
- **Backend**: ASP.NET Core 6 Web API
- **Database**: MS SQL Server
- **Frontend**: Razor Pages
- **ORM**: Entity Framework Core 6

## 🛠️ Установка и настройка

### Предварительные требования
| Компонент | Ссылка для скачивания |
|-----------|-----------------------|
| .NET 6 SDK | [Download](https://dotnet.microsoft.com/ru-ru/download/dotnet/6.0) |
| SQL Server | [Download](https://www.microsoft.com/ru-ru/sql-server/sql-server-downloads) |
| SSMS | [Download](https://learn.microsoft.com/ru-ru/ssms/download-sql-server-management-studio-ssms) |

### 1. Клонирование репозитория
```bash
git clone https://github.com/Kf9r/RemoteProject.git
cd RemoteProject
```
### 2. Настройка базы данных
1. Создайте БД в SQL Server
2. Обновите строку подключения:
```json
// ProductApi/appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_db;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```
### 3. Изменение портов на свои 
в ApiService.cs

```c sharp
// ProductWeb/Services/ApiService.cs
_httpClient.BaseAddress = new Uri("https://localhost:7100"); 
```

## 🚀 Запуск проекта
1. Запуск Api
```bash
dotnet run --project ProductApi
```
2. Запуск веб-приложения
```bash
dotnet run --project ProductWeb
```