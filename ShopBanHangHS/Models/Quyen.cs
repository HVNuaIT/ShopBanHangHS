using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBanHangHS.Models
{
    [Table("Quyen")]
    public class Quyen
    {
        [Key]
        public int maQuyen { get; set; }
        public string tenQuen { get; set; }

    }
}
