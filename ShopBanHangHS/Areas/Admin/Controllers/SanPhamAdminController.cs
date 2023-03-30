using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBanHangHS.Areas.Admin.Data;
using ShopBanHangHS.Areas.Admin.Models;
using System.Linq;

namespace ShopBanHangHS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamAdminController : Controller
    {
        private readonly DBContextAdmin db; 
        public SanPhamAdminController(DBContextAdmin _db)
        {

            db = _db;
        }
        public IActionResult Index()
        {
            var check = db.SanPhams.ToList();
            return View(check);
        }
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(SanPham dm)
        {
            var ds = db.DanhMucs.ToList();
            ViewBag.ds = ds;
          
          
            db.Attach(dm);
            db.SanPhams.Add(dm);
            db.SaveChanges();
            return Redirect("/Admin/SanPhamAdmin/Index");
        }
        [Route("Admin/[controller]/[action]")]
        public IActionResult Delete(int id)
        {
            var check = db.SanPhams.Where(x => x.maSanPham == id).FirstOrDefault();
            return View(check);
        }
        [Route("Admin/[controller]/[action]")]
        [HttpPost]
        public IActionResult Delete(SanPham bietThu, int id)
        {
            // db.Attach(bietThu);
            // db.Entry(id).State = EntityState.Deleted;
            var check = db.SanPhams.SingleOrDefault(s => s.maSanPham == id);
            db.SanPhams.Remove(check);
            db.SaveChanges();
            return Redirect("/Admin/SanPhamAdmin/Index");
        }
        [Route("Admin/[controller]/[action]")]
        public ActionResult Details(int id)
        {
            var check = db.SanPhams.SingleOrDefault(s => s.maSanPham == id);

            return View(check);
        }
        [Route("Admin/[controller]/[action]")]
        public ActionResult Edit(int id)
        {
            var objds = db.SanPhams.Where(x => x.maSanPham == id).FirstOrDefault();
            return View(objds);

        }
        // POST: SanPhamAdminController/Edit/5
        [Route("Admin/[controller]/[action]")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SanPham sanPham, IFormCollection collection)
        {
            try
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();

                return Redirect("/Admin/SanPhamAdmin/Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
