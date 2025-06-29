using System.Net.Http.Json;
using ProductApi.Models;

namespace ProductWeb.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7027"); 
        }

        // Получение всех материалов
        public async Task<List<Material>> GetMaterialsAsync() =>
            await _httpClient.GetFromJsonAsync<List<Material>>("api/MaterialsData") ?? new();

        // Получение материала по ID
        public async Task<Material?> GetMaterialAsync(int id) =>
            await _httpClient.GetFromJsonAsync<Material>($"api/MaterialsData/{id}");

        // Добавление нового материала
        public async Task AddMaterialAsync(Material material) =>
            await _httpClient.PostAsJsonAsync("api/MaterialsData", material);

        // Обновление материала
        public async Task UpdateMaterialAsync(int id, Material material) =>
            await _httpClient.PutAsJsonAsync($"api/MaterialsData/{id}", material);

        // Удаление материала
        public async Task DeleteMaterialAsync(int id) =>
            await _httpClient.DeleteAsync($"api/MaterialsData/{id}");
    }
}