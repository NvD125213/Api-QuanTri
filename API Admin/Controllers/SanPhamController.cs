using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModel;
using BLL.Interface;

namespace API_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {

        private ISanPhamBLL _spBLL;
        public SanPhamController(ISanPhamBLL spBLL)
        {
            _spBLL = spBLL;
        }
        [Route("GetAll-SanPham")]
        [HttpGet]
        public List<SanPhamModel> GetAll()
        {
            return _spBLL.GetAllListSP();
        }
        [Route("GetSanPham-ByID")]
        [HttpGet]
        public SanPhamModel GetDatabyID(int id)
        {
            return _spBLL.GetSanPhambyID(id);
        }


        [Route("Create-SanPham")]
        [HttpPost]
        public IActionResult Create([FromBody] SanPhamModel model)
        {
            if(model == null)
                return BadRequest(ModelState);
            else 
            {
                var result = _spBLL.Create(model);
                return Ok(result);
            }    
        }    
        [Route("Update-SanPham")]
        [HttpPut]
        public IActionResult Update([FromBody] SanPhamModel model)
        {
            if (model == null)
                return BadRequest(ModelState);
            else
            {
                var result = _spBLL.Update(model);
                return Ok(result);
            }
        }
        [Route("Delete-SanPham")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var success = _spBLL.Delete(id);
            return Ok("Xóa thành công");
        }
       [Route("Search-TheoDanhMuc")]
       [HttpPost]
        public IActionResult SearchDanhMuc([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tensp = "";
                if (formData.Keys.Contains("tensp") && !string.IsNullOrEmpty(Convert.ToString(formData["tensp"]))) { tensp = Convert.ToString(formData["tensp"]); }
                var danhmuc = int.Parse(formData["danhmuc"].ToString());

                long total = 0;
                var data = _spBLL.SearchTheoDM(page, pageSize, out total, tensp, danhmuc);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("Search-TheoGia")]
        [HttpPost]
        public IActionResult SearchGia([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var max = int.Parse(formData["giamax"].ToString());
                var min = int.Parse(formData["giamin"].ToString());

                long total = 0;
                var data = _spBLL.SearchTheoGia(page, pageSize, out total, max, min);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
