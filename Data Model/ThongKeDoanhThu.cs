using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ThongKeDoanhThu
    {
        public int SanPhamID { get; set; }
        public string Ten { get; set; }
        public DateTime? NgayDen { get; set; }
        public int TongSL { get; set; }
        public decimal TongGia { get; set; }
        public decimal TongTien { get; set; }

    }
}
