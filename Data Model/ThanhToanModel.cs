using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ThanhToanModel
    {
        [Key]
        public int ThanhToanID { get; set; }
        [Required]
        public string Ten { get; set; }
        public string PhuongThuc { get; set; }
        public string NhaCC { get; set; }
        public double SoTK { get; set; }
        [ForeignKey("tbl_User")]
        public int UserID { get; set; }
    }
}
