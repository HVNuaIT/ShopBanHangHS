using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBanHangHS.Areas.Admin.Models
{
    [Table("SanPham")]
    public  class SanPham
    {
        [Key]
        public int maSanPham { get; set; }
        [Required(ErrorMessage ="Xin Nhập Vào Tên Sản Phẩm")]
        [Display(Name = "Tên Sản Phẩm")]
        public string tenSanPham { get; set; }
       
        [Required(ErrorMessage = "Xin Nhập Vào Gía")]
        [Display(Name = "Giá")]
        public double? Gia {  get; set; }
        [Display(Name = "Số Lượng ")]
        [Required(ErrorMessage = "Xin Nhập Vào Số Lượng")]
        public int? soLuong { get; set; }
        [Display(Name = "Hình Ảnh")]
        [Required(ErrorMessage = "Xin Nhập Vào Hinh Ảnh")]
        public string HinhAnh { get; set; }
        [Display(Name = "Mô Tả")]
        [Required(ErrorMessage = "Xin Nhập Vào Mô Tả")]
        public string moTa { get; set; }
        [Display(Name = "Danh Mục")]
        public int? maLoai { get; set; }
        [ForeignKey("maLoai")]
        public DanhMuc danhMuc { get; set; }

    }
}
