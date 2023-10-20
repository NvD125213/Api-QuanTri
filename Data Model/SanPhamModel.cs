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
        public string SeoTitle { get; set; }
        public bool TrangThai { get; set; }
        public string ListAnh { get; set; }
        public string Anh { get; set; }
        public double Gia { get; set; }
        public double KhuyenMai { get; set; }

        public int SoLuongTon { get; set; }
        public int BaoHanh { get; set; }
        public DateTime SanPhamHot { get; set; }
        public string ThongSoChiTiet { get; set; }
        public int View { get; set; }
        [ForeignKey("DanhMuc")]
        public List<DanhMucModel> DanhMucID { get; set; }
        [ForeignKey("NhaCungCap")]
        public List<NhaCungCapModel> NhaCCID { get; set; }



    }
}
