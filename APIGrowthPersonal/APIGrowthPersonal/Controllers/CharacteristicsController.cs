
using APIGrowthPersonal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIGrowthPersonal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacteristicsController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        // GET: api/Users/5
        
        //public CharacteristicsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Characteristics>> GetCharacteristics(int id)
        //{
        //    var characteristics = await _context.Characteristics.FirstOrDefaultAsync();

        //    if (characteristics == null)
        //    {
        //        return NotFound();
        //    }

        //    return characteristics;
        //}
    }
}
