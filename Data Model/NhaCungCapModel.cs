using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class NhaCungCapModel
    {
        [Key]
        public int NhaCCID { get; set; }
        [Required]
        public string TenNCC { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
    }
}
