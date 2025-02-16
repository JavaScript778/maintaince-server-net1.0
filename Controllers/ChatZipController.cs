using Microsoft.AspNetCore.Mvc;
using maintaince_server_net.Data;
using maintaince_server_net.Models;

namespace maintaince_server_net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatZipController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ChatZipController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("未选择文件");

            var uuid = Guid.NewGuid().ToString();
            var savePath = $"chat-{uuid}.zip";
            var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            if (!Directory.Exists(uploadDir))
                Directory.CreateDirectory(uploadDir);

            var filePath = Path.Combine(uploadDir, savePath);
            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            _db.ChatZips.Add(new ChatZip
            {
                PackageName = file.FileName,
                Path = filePath
            });
            await _db.SaveChangesAsync();

            return Ok(new { Message = "上传成功" });
        }
    }
}