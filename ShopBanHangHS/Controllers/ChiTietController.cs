using Microsoft.AspNetCore.Mvc;
using ShopBanHangHS.Data;
using System.Linq;

namespace ShopBanHangHS.Controllers
{
    public class ChiTietController : Controller
    {
        private readonly ShopContext db;

        public ChiTietController(ShopContext _db)
        {
            this.db = _db;
        }
        
        public IActionResult ChiTietSanPham(int Id)
        {
            return View(db.SanPhams.SingleOrDefault(p => p.maSanPham.Equals(Id)));
        }
    }
}
