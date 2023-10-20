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
    public class NhaCungCapRespository : INhaCungCapRespository
    {
        private IDatabaseHelper _dbHelper;

        private IConfiguration _cofiguration;


        public NhaCungCapRespository(IDatabaseHelper dbhelper, IConfiguration configuration)
        {
            _dbHelper = dbhelper;
            _cofiguration = configuration;
        }

        public bool Create(NhaCungCapModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "tbl_NhaCungCapInsert",
                "@Ten", model.TenNCC,
                "@SDT", model.SDT,
                "@Email", model.Email,
                "@DiaChi", model.DiaChi);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "tbl_NhaCungCapDelete", "@NhaCungCapID", id);
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

        public List<NhaCungCapModel> GetAll()
        {
            List<NhaCungCapModel> result = new List<NhaCungCapModel>();
            DataTable dt = new DataTable();
            SqlConnection sql = new SqlConnection(_cofiguration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("sp_get_all_nhacc", sql);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dt);
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                NhaCungCapModel model = new NhaCungCapModel();
                model.NhaCCID = Convert.ToInt32(dt.Rows[i]["NhaCungCapID"]);
                model.TenNCC = dt.Rows[i]["Ten"].ToString();
                model.SDT = dt.Rows[i]["SDT"].ToString();
                model.DiaChi = dt.Rows[i]["DiaChi"].ToString();
                model.Email = dt.Rows[i]["Email"].ToString();
                result.Add(model);

            }
            return result;


        }

        public NhaCungCapModel GetNhaCCByID(int id) 
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_ncc_by_id",
                     "@UserID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhaCungCapModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(NhaCungCapModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedure(out msgError, "tbl_NhaCungCapUpdate",
                    "@NhaCungCapID", model.NhaCCID,
                    "@Ten", model.TenNCC,
                    "@Email", model.Email,
                    "@SDT", model.SDT,
                    "@DiaChi", model.DiaChi);
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
