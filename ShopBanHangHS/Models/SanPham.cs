using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBanHangHS.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public int maSanPham { get; set; }
        [Required(ErrorMessage ="Xin Nhập Vào Tên Sản Phẩm")]
        public string tenSanPham { get; set; }
        public DanhMuc danhmuc { get; set; }
        [Required(ErrorMessage = "Xin Nhập Vào Gía")]
        public double? Gia {  get; set; }
        [Required(ErrorMessage = "Xin Nhập Vào Số Lượng")]
        public int? soLuong { get; set; }
        [Required(ErrorMessage = "Xin Nhập Vào Hinh Ảnh")]
        public string HinhAnh { get; set; }
        [Required(ErrorMessage = "Xin Nhập Vào Mô Tả")]
        public string moTa { get; set; }
    

    }
}
