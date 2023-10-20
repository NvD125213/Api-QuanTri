using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace BLL.Interface
{
    public interface INhaCungCapBLL
    {
        NhaCungCapModel GetNhaCCByID(int id);
        List<NhaCungCapModel> GetAll();
        bool Create(NhaCungCapModel model);
        bool Update(NhaCungCapModel model);
        bool Delete(int id);
    }
}
