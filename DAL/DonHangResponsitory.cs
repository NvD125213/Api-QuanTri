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
    public class DonHangResponsitory : IDonHangResponsitory
    {
        private IDatabaseHelper _dbHelper;

        private IConfiguration _cofiguration;
        public DonHangResponsitory(IDatabaseHelper dbhelper, IConfiguration configuration)
        {
            _dbHelper = dbhelper;
            _cofiguration = configuration;
        }

        public List<DonHangModel> GetDHChuaXuLy(int pageIndex, int pageSize, out long total)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "HienThiDonHangChuaXuLy",
                    "@page_index", pageIndex,
                    "@page_size", pageSize
                   
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DonHangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      

        public bool Update(DonHangModel model)
        {

            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "ChuyenDoiTrangThaiDonHang",
                "@DonHangID", model.DonHangID);
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

        public List<ThongKeDoanhThu> ThongKeDoanhThuTheoNgay(int pageIndex, int pageSize, out long total, DateTime? fr_NgayTao, DateTime? to_NgayTao)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "THONGKEDOANHTHU",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@fr_NgayTao", fr_NgayTao,
                    "@to_NgayTao", to_NgayTao

                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ThongKeDoanhThu>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
    }
}
