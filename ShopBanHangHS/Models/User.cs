using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBanHangHS.Models
{
    [Table("TaiKhoan")]
    public class User
{
    
        [Key]
        public int maTaiKhoan { get; set; }
        [Required(ErrorMessage ="Không để trống")]
        public string ten { get; set; }
        [Required(ErrorMessage = "Không để trống")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Không để trống")]
        public string matKhau { get; set; }
        [Required(ErrorMessage = "Không để trống")]
        public bool quyen { get; set; }
        [Required(ErrorMessage = "Không để trống")]
        public string diaChi { get; set; }
        [Required(ErrorMessage ="Khong De Trong")]
        [StringLength(10)]
        public string soDT { get; set; }
		public bool xacThucEmail { get; set; }
		public Guid ActivationCode { get; set; }


	}
}
