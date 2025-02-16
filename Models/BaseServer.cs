using System.ComponentModel.DataAnnotations.Schema;

namespace maintaince_server_net.Models
{
    public class BaseServer
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("名称")]
        public string Name { get; set; }

        [Column("链接")]
        public string Url { get; set; }

        [Column("状态")]
        public string Status { get; set; } = "未知"; // 存活/失活/未知

        [Column("更新包")]
        public string LastPackage { get; set; }

        [Column("更新时间")]
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}