using Microsoft.AspNetCore.Mvc;
using ShopBanHangHS.Data;
using ShopBanHangHS.Models;
using System.Collections.Generic;
using ShopBanHangHS.Help;
using System.Linq;
using System;

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
                

            return View(Carts);
            
        }
        [HttpPost]
        public IActionResult COD( string address,string note)
        {

            var giohang = Carts;
            var checkgio = giohang.FirstOrDefault();
            var use = Userss;
            var checkUs = use.FirstOrDefault();
            Order order = new Order();
            order.ngayMuaHang = DateTime.Now;
            order.ghiChu = note;
            order.diaChi = address;
            order.Email = checkUs.Email;
            order.TenKhach = checkUs.ten;
            order.maTaiKhoan = checkUs.maTaiKhoan;
            order.maSanPham = checkgio.SanPhamID;
            order.trangThai = "Chưa Thanh Toán";
            order.SoDienThoai = checkUs.soDT;
            order.thanhTien = checkgio.ThanhTien;
            db.Orders.Add(order);
            db.SaveChanges();
          
            HttpContext.Session.Remove("GioHang");
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
