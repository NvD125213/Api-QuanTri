using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class UserModel
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string Ten { get; set; }
        public string Email { get; set; }

        public string SDT { get; set; }
        public string MatKhau { get; set; }
        public string token { get; set; }

    }
}
