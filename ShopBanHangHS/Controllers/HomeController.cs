using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopBanHangHS.Data;
using ShopBanHangHS.Help;
using ShopBanHangHS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ShopBanHangHS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopContext db  ;
  
        public HomeController(ILogger<HomeController> logger,ShopContext _db)
        {
            _logger = logger;
            db=_db;
        }
        public IActionResult Index()
        {
            var checkSanPham = db.SanPhams.ToList();
            var checkdanhmuc = db.DanhMucs.ToList();
            DanhSach ds  = new DanhSach();
            ds.dsSanPham = checkSanPham;
       ds.dsDanhMuc= checkdanhmuc;
            return View(ds);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
