using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DAL.Interface;
using DAL.Helper.Interface;
using DAL.Helper;


namespace DAL
{
    public class UserRespository : IUserRespository
    {

        private IDatabaseHelper _dbHelper;


        public UserRespository(IDatabaseHelper dbhelper)
        {
            _dbHelper = dbhelper;
        }
        public bool CreateUser(UserModel model)
        {

            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_user",
                "@Ten", model.Ten,
                "@SDT", model.SDT,
                "@Email", model.Email,
                "@MatKhau", model.MatKhau);
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

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool GetListUser(UserModel model)
        {

            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_get_all_users");
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

        public List<UserModel> GetListUser()
        {
            
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_users");
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return result.ConvertTo<UserModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserModel> Search(int pageIndex, int pageSize, out long total, string ten, string email)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_search_user",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ten", ten,
                    "@Email", email);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<UserModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ThongKeNguoiDungTopModel> ThongKeTop(DateTime? fr_date, DateTime? to_date)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "THONGKETOPNGUOIDUNG",
                    "@fm_Date", fr_date,
                    "@to_Date", to_date);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ThongKeNguoiDungTopModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUser(UserModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedure(out msgError, "sp_update_user",
                    "@UserID", model.UserID,
                    "@Ten", model.Ten,
                    "@Email", model.Email,
                    "@SDT", model.SDT);
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
