namespace ShopBanHangHS.Models
{
    public class CartItem
    {
        public int SanPhamID { get; set; }
        public string TenSanPham { get; set; }
        public string Hinh { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien
        {
            get
            {
                return (SoLuong * DonGia);
            }
        }
     
    }

}
