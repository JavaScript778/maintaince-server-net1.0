using System.ComponentModel.DataAnnotations.Schema;

namespace maintaince_server_net.Models
{
    public class ChatZip
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("更新包")]
        public string PackageName { get; set; }

        [Column("路径")]
        public string Path { get; set; }

        [Column("创建时间")]
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}