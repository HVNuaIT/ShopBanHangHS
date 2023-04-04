using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBanHangHS.Areas.Admin.Models
{
    [Table("DanhMuc")]
    public class DanhMuc
    {
        [Key]
        public int maDanhMuc { get; set; }
        [Required(ErrorMessage ="Xin Nhập Vào Tên Danh Mục ")]
        [Display(Name = "Tên Danh Mục")]
        public string tenDanhMuc { get; set; }
      
        public ICollection<SanPham> SanPhams { get; set; }
    }
}
