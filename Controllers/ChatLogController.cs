using Microsoft.AspNetCore.Mvc;
using maintaince_server_net.Data;
using Microsoft.EntityFrameworkCore;

namespace maintaince_server_net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatLogController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ChatLogController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var logs = await _db.ChatLogs.ToListAsync();
            return Ok(logs);
        }
    }
}