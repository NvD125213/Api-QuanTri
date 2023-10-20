using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DonHangModel
    {
        [Key]
        public int DonHangID { get; set; }
        [Required]
        public DateTime NgayDat { get; set; }
        public int TrangThai { get; set; }
        public int TinhTrang { get; set; }
        public DateTime NgayDen { get; set; }
        public double GiamGia { get; set; }
        public List<ChiTietDonHangModel> list_json_chitiethanghoa { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }


    }
    public class ChiTietDonHangModel
    {
        [ForeignKey("tbl_DonHang")]
        public int DonHangID { get; set; }
        [ForeignKey("tbl_SanPham")]
        public int SanPhamID { get; set; }
        public string TenSanPham { get; set; }
        public double Gia { get; set; }
        public int SoLuong { get; set; }
        [ForeignKey("tbl_ThanhToan")]
        public int ThanhToanID { get; set; }

    }
}
