using Microsoft.EntityFrameworkCore;

namespace AutofacProject.Models
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options) { }
        public DbSet<Music> Musics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 使用 Fluent API 配置表名转换规则
            modelBuilder.Entity<Music>().ToTable("Music");
        }

    }
}
