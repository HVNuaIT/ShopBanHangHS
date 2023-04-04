using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBanHangHS.Data;
using ShopBanHangHS.Models;
using System.Linq;

namespace ShopBanHangHS.Controllers
{
    public class DanhMucController : Controller
    {
        private readonly ShopContext db;
        public DanhMucController(ShopContext _db)
        {

            db = _db;
        }
        public IActionResult Index(int id )
        {
            var check = db.SanPhams.Where(x=>x.maLoai==id).ToList();
            DanhSach ds = new DanhSach();
            ds.dsSanPham = check;
            return View(ds);
        }
                
                
               
       
    }
}
