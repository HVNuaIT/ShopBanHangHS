using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBanHangHS.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int maDatHang { get; set; }
        public User User { get; set; }
        public string diaChiGH { get; set; }  
        public string LoiNhan { get; set; }
     
        public SanPham SanPham { get; set; }
        public string trangThai { get; set; }
    }
}
