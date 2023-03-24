using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace ShopBanHangHS.Models
{
    public class DanhSach
    {
        public List<SanPham> dsSanPham { get; set; }
        public List<DanhMuc> dsDanhMuc { get; set; }
        
    }
}
