using Microsoft.EntityFrameworkCore;
using ShopBanHangHS.Areas.Admin.Models;


namespace ShopBanHangHS.Areas.Admin.Data
{
    public class DBContextAdmin:DbContext
    {
        public DBContextAdmin(DbContextOptions options) : base(options) { }

        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
