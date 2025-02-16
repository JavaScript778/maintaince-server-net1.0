using System.ComponentModel.DataAnnotations.Schema;

namespace maintaince_server_net.Models
{
    public class BaseLog
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("更新包")]
        public string PackageName { get; set; }

        [Column("服务器名称")]
        public string ServerName { get; set; }

        [Column("服务器地址")]
        public string ServerAddress { get; set; }

        [Column("更新结果")]
        public int UpdateResult { get; set; } // 1=成功，0=失败

        [Column("创建时间")]
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}