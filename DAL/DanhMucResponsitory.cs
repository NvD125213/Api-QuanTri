using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class DanhMucResponsitory : IDanhMucResponsitory
    {
        private IDatabaseHelper _dbHelper;
        private IConfiguration _config;


        public DanhMucResponsitory(IDatabaseHelper dbhelper, IConfiguration config)
        {
            _dbHelper = dbhelper;
            _config = config;
        }
        public bool Create(DanhMucModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_CreateDanhMuc",
                "@TenDM", model.TenDM,
                "@SeoTitle", model.SeoTitle,
                "@TrangThai", model.TrangThai,
                "@ThuTu", model.ThuTu,
                "@ParentID", model.ParentID);
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

        public DanhMucModel Delete(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_DeleteDanhMuc", "@DanhMucID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return result.ConvertTo<DanhMucModel>().FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public List<DanhMucModel> GetAll()
        {
            List<DanhMucModel> result = new List<DanhMucModel>();
            DataTable dt = new DataTable();
            SqlConnection sql = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("sp_get_danhmuc_all", sql);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DanhMucModel model = new DanhMucModel();
                model.DanhMucID = Convert.ToInt32(dt.Rows[i]["DanhMucID"]);
                model.TenDM = dt.Rows[i]["TenDM"].ToString();
                model.SeoTitle = dt.Rows[i]["SeoTitle"].ToString();
                model.TrangThai = dt.Rows[i]["TrangThai"] != DBNull.Value ? Convert.ToInt32(dt.Rows[i]["TrangThai"]) : 0;  // Trường có giá trị Null
                model.ThuTu = dt.Rows[i]["ThuTu"] != DBNull.Value ? Convert.ToInt32(dt.Rows[i]["ThuTu"]) : 0;
                model.ParentID = dt.Rows[i]["ParentID"] != DBNull.Value ? Convert.ToInt32(dt.Rows[i]["ParentID"]) : 0;
                result.Add(model);

            }
            return result;
        }

        public bool Update(DanhMucModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_UpdateDanhMuc",
                "@DanhMucID", model.DanhMucID,
                "@TenDM", model.TenDM,
                "@SeoTitle", model.SeoTitle,
                "@TrangThai", model.TrangThai,
                "@ThuTu", model.ThuTu,
                "@ParentID", model.ParentID);
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
