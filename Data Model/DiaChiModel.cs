using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DiaChiModel
    {
        [Key]
        public int DiaChiID { get; set; }
        [Required]
        public string GhiChu { get; set; }
        public string Xa { get; set; }
        public string Huyen { get; set; }
        public string ThanhPho { get; set; }
        [ForeignKey("tbl_User")]
        public int UserID { get; set; }
    }
}
