using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBanHangHS.Areas.Admin.Data;
using ShopBanHangHS.Areas.Admin.Models;
using ShopBanHangHS.Help;
using System.Collections.Generic;
using System.Linq;

namespace ShopBanHangHS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HoaDonAdminController : Controller
    {
        private readonly DBContextAdmin db;
        public HoaDonAdminController(DBContextAdmin _db)
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
                var check = db.Orders.ToList();
                return View(check);
            }
        }
        [Route("Admin/[Controller]/[Action]")]
        public IActionResult Details(int id)
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                var check = db.Orders.SingleOrDefault(x => x.maHoaDon == id);
                return View(check);
            }
        }
        [Route("Admin/[Controller]/[Action]")]
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
                var check = db.Orders.SingleOrDefault(x => x.maHoaDon == id);
                return View(check);
            }
        }
        [Route("Admin/[Controller]/[Action]")]
        [HttpPost]
        public IActionResult Delete(Order o,int id)
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                var check = db.Orders.Where(x => x.maHoaDon == id).FirstOrDefault();
                db.Orders.Remove(check);
                db.SaveChanges();
                return Redirect("/Admin/HoaDonAdmin/Index");
            }
        }
        [Route("Admin/[Controller]/[Action]")]
        public IActionResult Edit(int id)
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                var check = db.Orders.Where(x => x.maHoaDon == id).FirstOrDefault();
                return View(check);
            }
        }
        [Route("Admin/[Controller]/[Action]")]
        [HttpPost]
        public IActionResult Edit(Order o, int id)
        {
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            if (checkUs == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                db.Entry(o).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/Admin/HoaDonAdmin/Index");
            }
        }
    }
}
