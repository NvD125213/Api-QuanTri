using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DAL.Interface;
using DAL.Helper.Interface;
using DAL.Helper;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class SanPhamResponsitory : ISanPhamResponsitory
    {
        private IDatabaseHelper _dbHelper;

        private IConfiguration _cofiguration;
        public SanPhamResponsitory(IDatabaseHelper dbhelper, IConfiguration configuration)
        {
            _dbHelper = dbhelper;
            _cofiguration = configuration;
        }

        public bool Create(SanPhamModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "CreateSanPham",
                "@Ten", model.Ten,
                "@SeoTitle", model.SeoTitle,
                "@TrangThai", model.TrangThai,
                "@List_Anh", model.ListAnh,
                "@Anh", model.Anh,
                "@Gia", model.Gia,
                "@KhuyenMai", model.KhuyenMai,
                "@SoLuongTon", model.SoLuongTon,
                "@BaoHanh", model.BaoHanh,
                "@SanPhamHot",model.SanPhamHot,
                "@MoTa",model.MoTa,
                "@ThongSoChiTiet",model.ThongSoChiTiet,
                "@View", model.View,
                "@DanhMucID",model.DanhMucID,
                "@NhaCungCapID",model.NhaCungCapID);;

                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int id)
        {

            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "tbl_SanPhamDelete", "@SanPham", id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanPhamModel> GetAllListSP()
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetListSanPham");
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return result.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SanPhamModel GetSanPhambyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanpham_get_by_id",
                     "@MaHoaDon", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPhamModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanPhamModel> SearchTheoDM(int pageIndex, int pageSize, out long total, string tensp, int danhmuc)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "SearchSanPham",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@TenSP", tensp,
                    "@DanhMuc", danhmuc
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

   
        public bool Update(SanPhamModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "UpdateProduct",
                "@SanPhamID", model.SanPhamID,
                "@Ten", model.Ten,
                "@SeoTitle", model.SeoTitle,
                "@TrangThai", model.TrangThai,
                "@List_Anh", model.ListAnh,
                "@Anh", model.Anh,
                "@KhuyenMai", model.KhuyenMai,
                "@SoLuongTon", model.SoLuongTon,
                "@BaoHanh", model.BaoHanh,
                "@SanPhamHot", model.SanPhamHot,
                "@MoTa", model.MoTa,
                "@ThongSoChiTiet", model.ThongSoChiTiet,
                "@DanhMucID",model.DanhMucID,
                "@NhaCungCapID",model.NhaCungCapID);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanPhamModel> SearchTheoGia(int pageIndex, int pageSize, out long total, int giaMax, int giaMin)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "SearchSanPhamQuaGia",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@MaxPrice", giaMax,
                    "@MinPrice", giaMin
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
