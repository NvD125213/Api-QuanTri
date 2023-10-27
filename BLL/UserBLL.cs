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
    public class UserBLL : IUserBLL
    {

        private IUserRespository _res;

        private string secret;
        public UserBLL(IUserRespository res, IConfiguration config)
        {

            _res = res;
            secret = config["AppSettings:Secret"];
        }

        public bool CreateUser(UserModel model)
        {
            return _res.CreateUser(model);

        }

        public bool DeleteUser(int id)
        {
            return _res.DeleteUser(id);
        }

        public List<UserModel> GetListUser()
        {
            return _res.GetListUser();
        }

        public List<UserModel> Search(int pageIndex, int pageSize, out long total, string ten, string email)
        {

            return _res.Search(pageIndex, pageSize, out total, ten, email);
        }

        public List<ThongKeNguoiDungTopModel> ThongKeTop(DateTime? fr_date, DateTime? to_date)
        {
            return _res.ThongKeTop(fr_date, to_date);
        }

        public bool UpdateUser(UserModel model)
        {
            return _res.UpdateUser(model);
        }
    }
}
