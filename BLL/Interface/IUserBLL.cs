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
        bool GetListUser(UserModel model);
        bool CreateUser(UserModel model);

        bool DeleteUser(int id);
        public List<UserModel> Search(int pageIndex, int pageSize, out long total, string ten, string email);
    }
}
