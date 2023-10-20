using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class CommentModel
    {
        [Key]
        public int CommentID { get; set; }
        [Required]
        public string Ten { get; set; }
        public string Email { get; set; }
        public string NoiDung { get; set; }
        public int TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgaySuaDoi { get; set; }
        [ForeignKey("tbl_SanPham")]
        public int SanPhamID { get; set; }
    }
}
