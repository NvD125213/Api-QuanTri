using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using BLL.Interface;
using DataModel;
using DAL.Interface;

namespace BLL
{
    public class DonHangBLL : IDonHangBLL
    {
        private IDonHangResponsitory _res;

        public DonHangBLL(IDonHangResponsitory res, IConfiguration config)
        {

            _res = res;
        }

        public List<DonHangModel> GetDHChuaXuLy(int pageIndex, int pageSize, out long total)
        {
            return _res.GetDHChuaXuLy(pageIndex, pageSize, out total);
        }

      
        public List<ThongKeDoanhThu> ThongKeDoanhThuTheoNgay(int pageIndex, int pageSize, out long total, DateTime? fr_NgayTao, DateTime? to_NgayTao)
        {
            return _res.ThongKeDoanhThuTheoNgay(pageIndex, pageSize, out total, fr_NgayTao, to_NgayTao);
        }

        public bool Update(DonHangModel model)
        {
            return _res.Update(model);
        }
    }
}
