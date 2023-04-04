using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ShopBanHangHS.Areas.Admin.Models;
using System.Linq;
using ShopBanHangHS.Help;

namespace ShopBanHangHS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdminController : Controller
    {
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
                return View();
            }
           
        }
    }
}
