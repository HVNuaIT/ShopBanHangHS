using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBanHangHS.Areas.Admin.Models
{
    [Table("DatHang")]
    public class Order
    {
        [Key]
        public int maHoaDon { get; set; }
        [Display(Name = "Mã Tài Khoản")]
        public Nullable<int> maTaiKhoan { get; set; }
        [Display(Name = "Tên Người Dùng")]
        public string TenKhach { get; set; }
        [Display(Name = "Ngày Đặt")]
        public Nullable<System.DateTime> ngayMuaHang { get; set; }
        [Display(Name = "Ghi Chú")]
        public string ghiChu { get; set; }
        [Display(Name = "Số Điện Thoại")]
        public string SoDienThoai { get; set; }
        [Display(Name = "Địa Chỉ")]
        public string diaChi { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Trạng Thái Đơn Hàng")]
        public string trangThai { get; set; }
        [Display(Name = "ID Sản Phẩm")]
        public int maSanPham { get; set; }
        [Display(Name = "Thành Tiền")]
        public double thanhTien { get; set; }
        [Display(Name = "Số Lượng")]
        public int soluong { get; set; }
    }
}
