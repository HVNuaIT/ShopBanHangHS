using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ShopBanHangHS.Models;

namespace ShopBanHangHS.Data
{
    public class ShopContext:DbContext
    {
        public ShopContext(DbContextOptions options) : base(options) { }

       public   DbSet<SanPham> SanPhams { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Quyen> Quyens { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }

    }
}
