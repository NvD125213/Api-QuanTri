using BLL.Interface;
using DataModel;
using DAL.Interface;

namespace BLL
{
    public class ThanhToanBLL : IThanhToanBLL
    {
        private IThanhToanResponsitory _res;
        public ThanhToanBLL(IThanhToanResponsitory res)
        {
            _res = res;
        }
        public bool Create(ThanhToanModel model)
        {
            return _res.Create(model);
        }

        public bool Delete(int id)
        {
            return _res.Delete(id);
        }

        public List<ThanhToanModel> GetAll()
        {
            return _res.GetAll();
        }

        public ThanhToanModel GetNhaCCByID(int id)
        {
            return _res.GetNhaCCByID(id);
        }

        public bool Update(ThanhToanModel model)
        {
            return _res.Update(model);
        }
    }
}
