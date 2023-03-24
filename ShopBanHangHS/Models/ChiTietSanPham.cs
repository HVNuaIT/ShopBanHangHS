using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ShopBanHangHS.Models
{
    public class ChiTietSanPham
    {
        [Key]
        public int maChiTiet { get; set; }
        [Required]
        public SanPham maSanPham { get; set; }
        [Required]
        public DanhMuc maDanhMuc { get; set; }
        public double? thanhTien { get; set; }
    
    }
}
