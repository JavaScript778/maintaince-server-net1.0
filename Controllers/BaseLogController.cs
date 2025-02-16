using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using maintaince_server_net.Data;
using maintaince_server_net.Models;

namespace maintaince_server_net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseLogController : ControllerBase
    {
        private readonly AppDbContext _db;

        public BaseLogController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/base_log/list/1（分页查询日志）
        [HttpGet("list/{page}")]
        public async Task<IActionResult> List(int page = 1)
        {
            const int pageSize = 10;
            var query = _db.BaseLogs.OrderByDescending(x => x.Id);
            var total = await query.CountAsync();
            var data = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return Ok(new { Total = total, Data = data });
        }
    }
}