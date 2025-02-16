using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using maintaince_server_net.Data;
using maintaince_server_net.Models;

namespace maintaince_server_net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseZipController : ControllerBase
    {
        private readonly AppDbContext _db;

        // 依赖注入数据库上下文
        public BaseZipController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/base_zip/list/1（分页查询）
        [HttpGet("list/{page}")]
        public async Task<IActionResult> List(int page = 1)
        {
            const int pageSize = 10;
            var query = _db.BaseZips.OrderByDescending(x => x.Id);
            var total = await query.CountAsync();
            var data = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return Ok(new { Total = total, Data = data });
        }

        // POST: api/base_zip/save（上传ZIP文件）
        [HttpPost("save")]
        public async Task<IActionResult> Save(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("未选择文件");

            // 生成唯一文件名和路径
            var uuid = Guid.NewGuid().ToString();
            var savePath = $"base-{uuid}.zip";
            var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            if (!Directory.Exists(uploadDir))
                Directory.CreateDirectory(uploadDir);

            var filePath = Path.Combine(uploadDir, savePath);
            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // 保存记录到数据库
            _db.BaseZips.Add(new BaseZip
            {
                PackageName = file.FileName,
                Path = filePath
            });
            await _db.SaveChangesAsync();

            return Ok(new { Message = "上传成功" });
        }
    }
}