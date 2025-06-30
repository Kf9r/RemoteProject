using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsDataController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MaterialsDataController(AppDbContext context)
        {
            _context = context;
        }

        // GET Запросы: api/MaterialsData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetMaterials()
        {
            return await _context.Materials.ToListAsync();
        }

        // GET Запрос: api/MaterialsData/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterial(int id)
        {
            var material = await _context.Materials.FindAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            return material;
        }

        // POST Запрос: api/MaterialsData
        [HttpPost]
        public async Task<ActionResult<Material>> PostMaterial(Material material)
        {
            _context.Materials.Add(material);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterial", new { id = material.Material_ID }, material);
        }

        // PUT  Запрос: api/MaterialsData/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, Material material)
        {
            if (id != material.Material_ID) return BadRequest();
            
            _context.Entry(material).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }
        
        private bool MaterialExists(int id)
        {
            return _context.Materials.Any(e => e.Material_ID == id);
        }

        // DELETE Запрос: api/MaterialsData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var material = await _context.Materials.FindAsync(id);
            if (material == null) return NotFound();

            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
