using System.Collections.Generic;

namespace ShopBanHangHS.Areas.Admin.Models
{
    public class DanhSachAdmin
    {
        public List<User> Users { get; set; }
        public List<Order>Orders  { get; set; }
        public List<SanPham>sanPhams  { get; set; }
      
    }
}
