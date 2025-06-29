using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductApi.Models;  // Убедитесь, что этот using есть
using ProductWeb.Services;

namespace ProductWeb.Pages;

public class IndexModel : PageModel
{
    private readonly ApiService _apiService;

    public List<Material> Materials { get; set; } = new(); // Исправлено Matrial -> Material

    public IndexModel(ApiService apiService) => _apiService = apiService;

    public async Task OnGetAsync() => Materials = await _apiService.GetMaterialsAsync();
}