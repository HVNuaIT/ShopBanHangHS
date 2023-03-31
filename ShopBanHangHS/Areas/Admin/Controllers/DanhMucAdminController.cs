using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBanHangHS.Areas.Admin.Data;
using ShopBanHangHS.Areas.Admin.Models;
using ShopBanHangHS.Data;
using ShopBanHangHS.Help;
using System;
using System.Collections.Generic;
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
            if (checkUs == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                var check = db.DanhMucs.ToList();
                return View(check);
            }
            
        }
        public IActionResult Create()
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                DanhMuc danhMuc = new DanhMuc();
                return View(danhMuc);
            }
        }

        [HttpPost]
        public IActionResult Create(DanhMuc dm)
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                db.Attach(dm);
                db.DanhMucs.Add(dm);
                db.SaveChanges();
                return Redirect("/Admin/DanhMucAdmin/Index");
            }
        }
        [Route("Admin/[controller]/[action]")]
        public IActionResult Delete(int id)
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                var check = db.DanhMucs.Where(x => x.maDanhMuc == id).FirstOrDefault();
                return View(check);
            }
        }
        [Route("Admin/[controller]/[action]")]
        [HttpPost]
        public IActionResult Delete(DanhMuc bietThu,int id)
        {
            // db.Attach(bietThu);
            // db.Entry(id).State = EntityState.Deleted;
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                var check = db.DanhMucs.SingleOrDefault(s => s.maDanhMuc == id);
                db.DanhMucs.Remove(check);
                db.SaveChanges();
                return Redirect("/Admin/DanhMucAdmin/Index");
            }
        }
        [Route("Admin/[controller]/[action]")]
        public ActionResult Details(int id)
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                var check = db.DanhMucs.SingleOrDefault(s => s.maDanhMuc == id);
                return View(check);
            }
        }
        [Route("Admin/[controller]/[action]")]
        public ActionResult Edit(int id)
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                var objds = db.DanhMucs.Where(x => x.maDanhMuc == id).FirstOrDefault();
                return View(objds);
            }
        }
        // POST: SanPhamAdminController/Edit/5
        [Route("Admin/[controller]/[action]")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DanhMuc danhMuc, IFormCollection collection)
        {
            try
            {
                var use = Userss;
                var checkUs = use.FirstOrDefault();
                if (checkUs == null)
                {
                    return Redirect("/Login/Index");
                }
                else
                {
                    db.Entry(danhMuc).State = EntityState.Modified;
                    db.SaveChanges();

                    return Redirect("/Admin/DanhMucAdmin/Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
