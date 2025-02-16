using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using maintaince_server_net.Data;
using maintaince_server_net.Models;

namespace maintaince_server_net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseServerController : ControllerBase
    {
        private readonly AppDbContext _db;

        public BaseServerController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/base_server/list/1（分页查询服务器列表）
        [HttpGet("list/{page}")]
        public async Task<IActionResult> List(int page = 1)
        {
            const int pageSize = 10;
            var query = _db.BaseServers.OrderByDescending(x => x.Id);
            var total = await query.CountAsync();
            var data = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return Ok(new { Total = total, Data = data });
        }

        // POST: api/base_server/save（新增或修改服务器）
        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] BaseServer server)
        {
            if (server.Id == 0)
                _db.BaseServers.Add(server);
            else
                _db.BaseServers.Update(server);

            await _db.SaveChangesAsync();
            return Ok(new { Message = "保存成功" });
        }

        // POST: api/base_server/delete（删除服务器）
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] long id)
        {
            var server = await _db.BaseServers.FindAsync(id);
            if (server == null)
                return NotFound("服务器不存在");

            _db.BaseServers.Remove(server);
            await _db.SaveChangesAsync();
            return Ok(new { Message = "删除成功" });
        }
    }
}