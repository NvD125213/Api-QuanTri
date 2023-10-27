using BLL.Interface;
using DataModel;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SanPhamBLL : ISanPhamBLL
    {
        private ISanPhamResponsitory _res;
        public SanPhamBLL(ISanPhamResponsitory res)
        {
            _res = res;
        }

        public bool Create(SanPhamModel model)
        {
            return _res.Create(model);
        }

        public bool Delete(int id)
        {
            return _res.Delete(id);
        }

        public List<SanPhamModel> GetAllListSP()
        {
            return _res.GetAllListSP();
        }

        public SanPhamModel GetSanPhambyID(int id)
        {
            return _res.GetSanPhambyID(id);
        }

        public List<SanPhamModel> SearchTheoDM(int pageIndex, int pageSize, out long total, string tensp, int danhmuc)
        {
            return _res.SearchTheoDM(pageIndex, pageSize, out total, tensp, danhmuc);
        }

        public List<SanPhamModel> SearchTheoGia(int pageIndex, int pageSize, out long total, int giaMax, int giaMin)
        {
            return _res.SearchTheoGia(pageIndex, pageSize, out total, giaMax, giaMin);
        }

        public bool Update(SanPhamModel model)
        {
            return _res.Update(model);
        }
    }
}
