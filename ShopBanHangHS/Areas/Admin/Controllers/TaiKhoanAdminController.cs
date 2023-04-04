using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShopBanHangHS.Areas.Admin.Data;
using ShopBanHangHS.Areas.Admin.Models;
using ShopBanHangHS.Data;
using BCryptNet = BCrypt.Net.BCrypt;
using System;
using System.Linq;
using System.Collections.Generic;
using ShopBanHangHS.Help;

namespace ShopBanHangHS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TaiKhoanAdminController : Controller
    {
        private readonly DBContextAdmin db;

        public TaiKhoanAdminController(DBContextAdmin _db)
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
                var check = db.Users.ToList();
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
                return View();
            }
        }
        [HttpPost]
        public IActionResult Create(User us)
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs.quyen == false)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                User user = new User();
                user.ten = us.ten;
                user.Email = us.Email;
                user.matKhau = us.matKhau;
                user.matKhau = BCryptNet.HashPassword(user.matKhau);
                user.diaChi = us.diaChi;
                user.soDT = us.soDT;
                user.quyen = us.quyen;
                user.ActivationCode = Guid.NewGuid();
                user.xacThucEmail = us.xacThucEmail;
                db.Users.Add(user);
                db.SaveChanges();
                return Redirect("/Admin/TaiKhoanAdmin/Index");
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
                var check = db.Users.Where(x => x.maTaiKhoan == id).FirstOrDefault();
                return View(check);
            }
        }
        [Route("Admin/[controller]/[action]")]
        [HttpPost]
        public IActionResult Delete(User bietThu, int id)
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs.quyen == false)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                var check = db.Users.SingleOrDefault(s => s.maTaiKhoan == id);
                db.Users.Remove(check);
                db.SaveChanges();
                return Redirect("/Admin/TaiKhoanAdmin/Index");
            }
        }

        public IActionResult Edit(int id)
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs.quyen == false)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                var check = db.Users.Where(x => x.maTaiKhoan == id).FirstOrDefault();
                return View(check);
            }
        }
        [Route("Admin/[controller]/[action]")]
        [HttpPost]
        public IActionResult Edit(User tk)
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs.quyen == false)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                db.Entry(tk).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/Admin/TaiKhoanAdmin/Index");
            }
        }
        [Route("Admin/[controller]/[action]")]
        public IActionResult Detail(int id)
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs.quyen == false)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                var check = db.Users.FirstOrDefault(s => s.maTaiKhoan == id);
                return View(check);
            }
        }
    }
}

    
