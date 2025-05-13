
using APIGrowthPersonal.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace APIGrowthPersonal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        //public ClassesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Classes>> GetClass(int id)
        //{
        //    var classes = await _context.Classes.FindAsync(id);
        //    if (classes == null) return NotFound();
        //    return classes;
        //}
    }
}
