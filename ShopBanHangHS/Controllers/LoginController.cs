using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBanHangHS.Data;
using ShopBanHangHS.Help;
using ShopBanHangHS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

using BCryptNet = BCrypt.Net.BCrypt;

namespace ShopBanHangHS.Controllers
{
    public class LoginController : Controller
    {
        private readonly ShopContext db;
      
        public LoginController(ShopContext _db)
        {
            db = _db;
        
        }
        public IActionResult Index()
        {
            return View();
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
        [HttpPost]
        public IActionResult Login(User user)
        {
            var kiemtra = Userss;
            var checkUs = kiemtra.SingleOrDefault(p => p.maTaiKhoan == user.maTaiKhoan);
            var check = db.Users.SingleOrDefault(s => s.Email == user.Email);
          
            if (check != null || BCryptNet.Verify(user.matKhau, check.matKhau)&& check.xacThucEmail == true)
            {
                
                   
                    kiemtra.Add(check);
                    HttpContext.Session.Set("Tk", kiemtra);
                    HttpContext.Session.SetString("Ten",kiemtra.FirstOrDefault().ten);
                    return RedirectToAction("Index", "Home");
                    
                
                
            }
            else
            {
                return View("Loi");
            }
            
        }

        public IActionResult DangKi()
        {

            return View();
        }

        [HttpPost]
        public IActionResult DangKi(User user, string ten, string email, string password, string diaChi, string sdt)
        {
            var check = db.Users.SingleOrDefault(x => x.Email == user.Email);
            if (check == null)
            {
                user.ten = ten;
                user.Email = email;
                user.matKhau = password;
                user.matKhau = BCryptNet.HashPassword(user.matKhau);
                user.diaChi = diaChi;
                user.soDT = sdt;
                user.quyen = false;
                user.ActivationCode = Guid.NewGuid();
                user.xacThucEmail = false;

            }
            SendVerificationLinkEmail(user.Email, user.ActivationCode.ToString());
            db.Users.Add(user);
            db.SaveChanges();
           
            ViewBag.Mess = "Đăng Kí Thành Công";
            return RedirectToAction("DangKi", "Login");


        }
        


        public IActionResult Thoat(User user)
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Loi()
        {
            return View();

        }

        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
          
            
              //  dc.Configuration.ValidateOnSaveEnabled = false;
                var v = db.Users.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
                if (v != null)
                {
                    v.xacThucEmail = true;
                    db.SaveChanges();
                    Status = true;
                }
                else
                {
                    ViewBag.Message = "Invalid Request";
                }
            
            ViewBag.Status = Status;
            return View();
        }
        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode)
        {
           var verifyUrl = Request.Scheme+"://"+ Request.Host+"/Login/VerifyAccount/" + activationCode;

            var fromEmail = new MailAddress("phuongnama121999@gmail.com", "ShopVP");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "stimrgvviqxqgxyq";
            string subject = "Your account is successfully created!";

            string body = "<br/><br/>Cảm ơn quý khách đã đăng kí tài khoản " +
                " Thành Công.Vui lòng click vào Link để thực hiện việc xác thực tài khoản và đăng nhập" +
                " <br/><br/><a href='" + verifyUrl + "'>" + verifyUrl + "</a> ";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }
    }
}


