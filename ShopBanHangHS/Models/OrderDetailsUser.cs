using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBanHangHS.Models
{
    [Table("OrderUser")]
    public class OrderDetailsUser
    {
        [Key]
        public int maOrderDetails { get; set; }
        public int mahang { get;set; }
        public int gia { get;set; }
        public DateTime ngayMua { get;set; }
        public string tinhtrang { get;set; }
        public int soluong { get;set; }
        public int maUser { get; set; }



    }
}
