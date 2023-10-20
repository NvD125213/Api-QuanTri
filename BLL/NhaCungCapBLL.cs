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
    public class NhaCungCapBLL : INhaCungCapBLL
    {
        private INhaCungCapRespository _res;

        public NhaCungCapBLL(INhaCungCapRespository res)
        {

            _res = res;
            
        }
        public bool Create(NhaCungCapModel model)
        {
            return _res.Create(model);
        }

        public bool Delete(int id)
        {
            return _res.Delete(id);
        }

        public List<NhaCungCapModel> GetAll()
        {
            return _res.GetAll();
        }

        public NhaCungCapModel GetNhaCCByID(int id)
        {
            return _res.GetNhaCCByID(id);
        }

        public bool Update(NhaCungCapModel model)
        {
            return _res.Update(model);
        }
    }
}
