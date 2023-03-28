using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBanHangHS.Models
{
    [Table("DatHang")]
    public class Order
    {
        [Key]
        public int maHoaDon { get; set; }
        public Nullable<int> maTaiKhoan { get; set; }
        public string TenKhach { get; set; }
        public Nullable<System.DateTime> ngayMuaHang { get; set; }
        public string ghiChu { get; set; }
        public string SoDienThoai { get; set; }
        public string diaChi { get; set; }
        public string Email { get; set; }
        public string trangThai { get; set; }
        public int maSanPham { get; set; }
        public double thanhTien { get; set; }
        public int soluong { get; set; }
    }
}
