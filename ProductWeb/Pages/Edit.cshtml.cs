using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductApi.Models;
using ProductWeb.Services;

namespace ProductWeb.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApiService _apiService;

        [BindProperty]
        public Material Material { get; set; } = new();

        public EditModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var material = await _apiService.GetMaterialAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            Material = material;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _apiService.UpdateMaterialAsync(Material.Material_ID, Material);
            return RedirectToPage("./Index");
        }
    }
}