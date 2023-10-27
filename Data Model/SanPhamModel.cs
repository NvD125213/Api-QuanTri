using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataModel
{
    public class SanPhamModel
    {
        [Key]
        public int SanPhamID { get; set; }
        [Required]
        public string Ten { get; set; }
        public bool SeoTitle { get; set; }
        public bool TrangThai { get; set; }
        public string ListAnh { get; set; }
        public string Anh { get; set; }
        public decimal Gia { get; set; }
        public decimal KhuyenMai { get; set; }
        public string MoTa { get; set; }

        public int SoLuongTon { get; set; }
        public int BaoHanh { get; set; }
        public DateTime SanPhamHot { get; set; }
        public string ThongSoChiTiet { get; set; }
        public int View { get; set; }
        [ForeignKey("DanhMuc")]
        public int DanhMucID { get; set; }
        [ForeignKey("NhaCungCap")]
        public int NhaCungCapID { get; set; }



    }
}
