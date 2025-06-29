using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductApi.Models;
using ProductWeb.Services;

namespace ProductWeb.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public Material Material { get; set; } = new();

        public CreateModel(ApiService apiService) => _apiService = apiService;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _apiService.AddMaterialAsync(Material);
            return RedirectToPage("./Index");
        }
    }
}