using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBanHangHS.Areas.Admin.Data;
using ShopBanHangHS.Areas.Admin.Models;
using ShopBanHangHS.Data;
using System;
using System.Linq;

namespace ShopBanHangHS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DanhMucAdminController : Controller
    {
        private readonly DBContextAdmin db;
        public DanhMucAdminController (DBContextAdmin _db)
        {
            db = _db;
        }       
        public IActionResult Index()
        {
            var check = db.DanhMucs.ToList();
            return View(check);
        }
        public IActionResult Create()
        {
            DanhMuc danhMuc = new DanhMuc();
            return View(danhMuc);
        }

        [HttpPost]
        public IActionResult Create(DanhMuc dm)
        {
                db.Attach(dm);
                db.DanhMucs.Add(dm);
                db.SaveChanges();           
                return Redirect("/Admin/DanhMucAdmin/Index");    
        }
        [Route("Admin/[controller]/[action]")]
        public IActionResult Delete(int id)
        {
            var check = db.DanhMucs.Where(x => x.maDanhMuc == id).FirstOrDefault();
            return View(check);
        }
        [Route("Admin/[controller]/[action]")]
        [HttpPost]
        public IActionResult Delete(DanhMuc bietThu,int id)
        {
            // db.Attach(bietThu);
            // db.Entry(id).State = EntityState.Deleted;
            var check = db.DanhMucs.SingleOrDefault(s => s.maDanhMuc == id);
            db.DanhMucs.Remove(check);
            db.SaveChanges();
            return Redirect("/Admin/DanhMucAdmin/Index");
        }
        [Route("Admin/[controller]/[action]")]
        public ActionResult Details(int id)
        { var check  = db.DanhMucs.SingleOrDefault(s=>s.maDanhMuc ==id);

            return View(check);
        }
        [Route("Admin/[controller]/[action]")]
        public ActionResult Edit(int id)
        {
            var objds = db.DanhMucs.Where(x => x.maDanhMuc == id).FirstOrDefault();
            return View(objds);
          
        }
        // POST: SanPhamAdminController/Edit/5
        [Route("Admin/[controller]/[action]")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DanhMuc danhMuc, IFormCollection collection)
        {
            try
            {
                 db.Entry(danhMuc).State= EntityState.Modified;
                    db.SaveChanges();
                
                return Redirect("/Admin/DanhMucAdmin/Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
