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
    public class ThanhToanResponsitory : IThanhToanResponsitory
    {
        private IDatabaseHelper _dbHelper;

        private IConfiguration _cofiguration;
        public ThanhToanResponsitory(IDatabaseHelper dbhelper, IConfiguration configuration)
        {
            _dbHelper = dbhelper;
            _cofiguration = configuration;
        }

        public bool Create(ThanhToanModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "tbl_ThanhToanInsert",
                "@ThanhToanID", model.ThanhToanID,
                "@Ten", model.Ten,
                "@PhuongThuc", model.PhuongThuc,
                "@NhaCC", model.NhaCC,
                "@SoTK",model.SoTK,
                );
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "tbl_ThanhToanDelete", "@ThanhToanID", id);
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

        public List<ThanhToanModel> GetAll()
        {

            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetAllThanhToan");
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return result.ConvertTo<ThanhToanModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ThanhToanModel GetNhaCCByID(int id)
        {

            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_thanhtoan_by_id",
                     "@UserID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ThanhToanModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(ThanhToanModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "tbl_ThanhToanUpdate",
                "@ThanhToanID", model.ThanhToanID,
                "@Ten", model.Ten,
                "@PhuongThuc", model.PhuongThuc,
                "@NhaCC", model.NhaCC,
                "@SoTK", model.SoTK,
              );
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
    }
}
