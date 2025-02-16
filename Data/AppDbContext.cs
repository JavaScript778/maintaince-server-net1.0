using Microsoft.EntityFrameworkCore;
using maintaince_server_net.Models;

namespace maintaince_server_net.Data
{
    public class AppDbContext : DbContext
    {
        // 基础服模块
        public DbSet<BaseZip> BaseZips { get; set; }
        public DbSet<BaseLog> BaseLogs { get; set; }
        public DbSet<BaseServer> BaseServers { get; set; }

        // 聊天服模块
        public DbSet<ChatZip> ChatZips { get; set; }
        public DbSet<ChatLog> ChatLogs { get; set; }
        public DbSet<ChatServer> ChatServers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 可在此配置表名或索引
            modelBuilder.Entity<ChatZip>().ToTable("chat_zip");
            modelBuilder.Entity<ChatLog>().ToTable("chat_log");
            modelBuilder.Entity<ChatServer>().ToTable("chat_server");
        }
    }
}