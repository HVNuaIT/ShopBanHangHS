using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBanHangHS.Data;
using ShopBanHangHS.Models;
using System.Collections.Generic;
using ShopBanHangHS.Help;
using System.Linq;
using System;

namespace ShopBanHangHS.Controllers
{
    public class GioHangController : Controller
    {
        private readonly ShopContext db;
        public GioHangController(ShopContext _db)
        {
            db = _db;
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
        public IActionResult ThemGH(int id, int soLuong)
        {
            var cart = Carts;
            var check = cart.SingleOrDefault(p => p.SanPhamID == id);
            if (check == null)// Chưa có trong giỏ
            {
                var checkdb = db.SanPhams.SingleOrDefault(p => p.maSanPham == id);
                check = new CartItem
                {
                    SanPhamID = id,
                    TenSanPham = checkdb.tenSanPham,
                    DonGia = Convert.ToDouble(checkdb.Gia),
                    SoLuong = soLuong,
                    Hinh = checkdb.HinhAnh
                };
                cart.Add(check);
            }
            else
            {

                check.SoLuong += soLuong;
            }
            
            HttpContext.Session.Set("GioHang", cart);
            return RedirectToAction("Index");
        }
        public IActionResult XoaGioHang(int id)
        {
            List<CartItem> gioHang = Carts;
            CartItem check = gioHang.SingleOrDefault(p => p.SanPhamID == id);
           
            if (check != null)
            {
                gioHang.Remove(check);
            }
            HttpContext.Session.Set("GioHang", gioHang);
            return View("Index");
           

        }
        public ActionResult SuaSoLuong(int SanPhamID, int soluongmoi)
        {
            List<CartItem> gioHang = Carts;
            CartItem check = gioHang.SingleOrDefault(p => p.SanPhamID == SanPhamID);

            if (check != null)
            {
                if (soluongmoi < 1 || soluongmoi > 100)
                {

                }
                else
                {
                    @ViewBag.GioError = "";
                    check.SoLuong = soluongmoi;
                }
            }
            HttpContext.Session.Set("GioHang", gioHang);
            return RedirectToAction("Index");


        }


    } 


    }

