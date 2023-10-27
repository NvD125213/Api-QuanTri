using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace BLL.Interface
{
    public interface IUserBLL
    {
        bool UpdateUser(UserModel model);
        List<UserModel> GetListUser();
        bool CreateUser(UserModel model);

        bool DeleteUser(int id);
        public List<ThongKeNguoiDungTopModel> ThongKeTop(DateTime? fr_date, DateTime? to_date);

        public List<UserModel> Search(int pageIndex, int pageSize, out long total, string ten, string email);
    }
}
