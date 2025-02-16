using Microsoft.AspNetCore.Mvc;
using maintaince_server_net.Data;
using Microsoft.EntityFrameworkCore;
using maintaince_server_net.Models;

namespace maintaince_server_net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatServerController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ChatServerController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] ChatServer server)
        {
            if (server.Id == 0)
                _db.ChatServers.Add(server);
            else
                _db.ChatServers.Update(server);

            await _db.SaveChangesAsync();
            return Ok(new { Message = "保存成功" });
        }
    }
}