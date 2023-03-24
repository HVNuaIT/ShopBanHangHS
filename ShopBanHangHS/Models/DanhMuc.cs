using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBanHangHS.Models
{
    [Table("DanhMuc")]
    public class DanhMuc
    {
        [Key]
        public int maDanhMuc { get; set; }
        [Required(ErrorMessage ="Xin Nhập Vào Tên Danh Mục ")]
        public string tenDanhMuc { get; set; }
   
    }
}
