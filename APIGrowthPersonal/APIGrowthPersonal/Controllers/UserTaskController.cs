
using APIGrowthPersonal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIGrowthPersonal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserTasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: api/usertasks
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<UserTask>>> GetUserTasks()
        //{
        //    return await _context.UserTasks.ToListAsync();
        //}

        //// GET: api/usertasks/5/10
        //[HttpGet("{userId}/{questId}")]
        //public async Task<ActionResult<UserTask>> GetUserTask(int userId, int questId)
        //{
        //    var userTask = await _context.UserTasks.FindAsync(userId, questId);

        //    if (userTask == null)
        //    {
        //        return NotFound();
        //    }

        //    return userTask;
        //}

        //// POST: api/usertasks
        //[HttpPost]
        //public async Task<ActionResult<UserTask>> PostUserTask(UserTask userTask)
        //{
        //    _context.UserTasks.Add(userTask);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetUserTask),
        //        new { userId = userTask.UserId, questId = userTask.QuestId }, userTask);
        //}
    }
}
