using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IThanhToanResponsitory
    {
        ThanhToanModel GetNhaCCByID(int id);
        List<ThanhToanModel> GetAll();
        bool Create(ThanhToanModel model);
        bool Update(ThanhToanModel model);
        bool Delete(int id);
    }
}
