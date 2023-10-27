using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace BLL.Interface
{
    public interface IThanhToanBLL
    {
        ThanhToanModel GetNhaCCByID(int id);
        List<ThanhToanModel> GetAll();
        bool Create(ThanhToanModel model);
        bool Update(ThanhToanModel model);
        bool Delete(int id);
    }
}
