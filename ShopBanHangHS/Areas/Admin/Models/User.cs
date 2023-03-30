using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBanHangHS.Areas.Admin.Models
{
    [Table("TaiKhoan")]
    public class User
{
    
        [Key]
        public int maTaiKhoan { get; set; }
        [Required(ErrorMessage ="Không để trống")]
        [Display(Name ="Tên Người Dùng")]
        public string ten { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Không để trống")]
        public string Email { get; set; }
        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage = "Không để trống")]
        public string matKhau { get; set; }
        [Display(Name = "Quyền Quản Trị")]
        [Required(ErrorMessage = "Không để trống")]
        public bool quyen { get; set; }
        [Display(Name = "Địa Chỉ")]
        [Required(ErrorMessage = "Không để trống")]
        public string diaChi { get; set; }
        [Display(Name = "Số Điện Thoại")]
        [Required(ErrorMessage ="Khong De Trong")]
        [StringLength(10)]
        public string soDT { get; set; }
        [Display(Name = "Trạng Thái Xác Thực Email")]
        public bool xacThucEmail { get; set; }
        [Display(Name = "Chuỗi Xác Thực")]
        public Guid ActivationCode { get; set; }


	}
}
