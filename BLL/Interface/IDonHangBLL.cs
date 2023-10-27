using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
namespace BLL.Interface
{
    public interface IDonHangBLL
    {
        bool Update(DonHangModel model);
        public List<ThongKeDoanhThu> ThongKeDoanhThuTheoNgay(int pageIndex, int pageSize, out long total, DateTime? fr_NgayTao, DateTime? to_NgayTao);
        public List<DonHangModel> GetDHChuaXuLy(int pageIndex, int pageSize, out long total);
    }
}
