using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
     public class ThongKeNguoiDungTopModel
     {
        public int UserID { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public decimal TongGia { get; set; }
        public List<ChiTietThongKe> list_json_ChiTietDonHang { get; set; }

    }
    public class ChiTietThongKe
    {
        public string TenSanPham { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }
    }
}
