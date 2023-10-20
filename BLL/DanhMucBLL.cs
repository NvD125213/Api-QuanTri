using BLL.Interface;
using DataModel;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DanhMucBLL : IDanhMucBLL
    {
        private IDanhMucResponsitory _res;

        public DanhMucBLL(IDanhMucResponsitory res)
        {
            _res = res;
        }



        public bool Create(DanhMucModel model)
        {
            return _res.Create(model);
        }

        public DanhMucModel Delete(int id)
        {
            return _res.Delete(id);
        }

        public List<DanhMucModel> GetAll()
        {
            return _res.GetAll();
        }

        public bool Update(DanhMucModel model)
        {
            return _res.Update(model);
        }
    }
}
