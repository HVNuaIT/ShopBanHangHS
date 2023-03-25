﻿using Microsoft.AspNetCore.Mvc;
using ShopBanHangHS.Data;
using ShopBanHangHS.Models;
using System.Collections.Generic;
using ShopBanHangHS.Help;
using System.Linq;

namespace ShopBanHangHS.Controllers
{
    public class ThanhToanController : Controller
    {
        private readonly ShopContext db; 
        public ThanhToanController(ShopContext _db)
        {
            this.db = _db;
        }
        public List<CartItem> Carts
        {
            get
            {
                var data = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (data == null)
                {
                    data = new List<CartItem>();

                }
                return data;
            }
        }
        public IActionResult Index()
        {
        
            return View(Carts);
            
        }
        public IActionResult COD()
        {
            var giohang = Carts;
            var checkgio = giohang.FirstOrDefault();
          
            return View("Index");
        }
        public IActionResult VNPAY()
        {
            var giohang = Carts;
            var checkgio = giohang.FirstOrDefault();
           

            return View("Index");
        }
    }
}
