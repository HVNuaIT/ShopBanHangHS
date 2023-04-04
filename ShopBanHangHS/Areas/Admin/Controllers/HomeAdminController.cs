using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ShopBanHangHS.Areas.Admin.Models;
using System.Linq;
using ShopBanHangHS.Help;
using ShopBanHangHS.Areas.Admin.Data;

namespace ShopBanHangHS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdminController : Controller
    {
        private readonly DBContextAdmin db;
        public HomeAdminController(DBContextAdmin _db)
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
            if (checkUs.quyen == false )
            {
                return Redirect("/Login/Index");
            }
            else
            {
                var checkdh = db.Orders.Count();
                var checkUser = db.Users.Count();
                var checksp=db.SanPhams.Count();
                 ViewBag.donhang = checkdh;
                ViewBag.Us = checkUser;
                ViewBag.sp = checksp;
                return View();
            }
           
        }
    }
}
