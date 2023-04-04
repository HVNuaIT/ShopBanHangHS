using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopBanHangHS.Areas.Admin.Data;
using ShopBanHangHS.Areas.Admin.Models;
using ShopBanHangHS.Help;
using System.Collections.Generic;
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
        public List<User> Userss
        {
            get
            {
                var data = HttpContext.Session.Get<List<User>>("Tk");
                if (data == null)
                {
                    data = new List<User>();

                }
                return data;
            }
        }
        public IActionResult Index()
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs.quyen == false)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                var check = db.SanPhams.ToList();
                return View(check);
            }
        }
        public IActionResult Create()
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs.quyen == false)
            {
                return Redirect("/Login/Index");
            }
            else
            {
               
                  ViewBag.maLoai = new SelectList(db.DanhMucs.ToList(), "maDanhMuc", "tenDanhMuc");
            
                return View();
            }
        }

        [HttpPost]
        public IActionResult Create(SanPham dm,int maDanhMuc)
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs.quyen == false)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                /*
                SanPham sp = new SanPham();
                sp.tenSanPham = dm.tenSanPham;
                sp.moTa = dm.moTa;
               sp.maLoai = maDanhMuc;
                sp.Gia = dm.Gia;
                sp.soLuong= dm.soLuong;
                sp.HinhAnh= dm.HinhAnh;*/
                db.SanPhams.Add(dm);
                db.SaveChanges();
                return Redirect("/Admin/SanPhamAdmin/Index");
            }
        }
        [Route("Admin/[controller]/[action]")]
        public IActionResult Delete(int id)
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs.quyen == false)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                var check = db.SanPhams.Where(x => x.maSanPham == id).FirstOrDefault();
                return View(check);
            }
        }
        [Route("Admin/[controller]/[action]")]
        [HttpPost]
        public IActionResult Delete(SanPham bietThu, int id)
        {
            // db.Attach(bietThu);
            // db.Entry(id).State = EntityState.Deleted;
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs.quyen == false)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                var check = db.SanPhams.SingleOrDefault(s => s.maSanPham == id);
                db.SanPhams.Remove(check);
                db.SaveChanges();
                return Redirect("/Admin/SanPhamAdmin/Index");
            }
        }
        [Route("Admin/[controller]/[action]")]
        public ActionResult Details(int id)
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs.quyen == false)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                var check = db.SanPhams.SingleOrDefault(s => s.maSanPham == id);

                return View(check);
            }
        }
        [Route("Admin/[controller]/[action]")]
        public ActionResult Edit(int id)
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs.quyen == false)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                var objds = db.SanPhams.Where(x => x.maSanPham == id).FirstOrDefault();
                return View(objds);
            }

        }
        // POST: SanPhamAdminController/Edit/5
        [Route("Admin/[controller]/[action]")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SanPham sanPham, IFormCollection collection)
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs.quyen == false)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();

                return Redirect("/Admin/SanPhamAdmin/Index");
            }
             
            
        }
    }
}
