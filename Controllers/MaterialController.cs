using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIhibridaASP.Data;
using APIhibridaASP.Models;

namespace APIhibridaASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MaterialController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMateriales()
        {
            var materiales = await _context.Material.ToListAsync();
            return Ok(materiales);
        }
    }
}
