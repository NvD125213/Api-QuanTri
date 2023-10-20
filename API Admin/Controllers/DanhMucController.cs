using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModel;
using BLL.Interface;
namespace API_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucController : ControllerBase
    {
        private IDanhMucBLL _dmBll;
        public DanhMucController(IDanhMucBLL dmBll)
        {
            _dmBll = dmBll;
        }
        [Route("Create-DanhMuc")]
        [HttpPost]
        public IActionResult CreateDanhMuc([FromBody] DanhMucModel model)
        {
            if (model == null)
            {
                return BadRequest("Dữ liệu người dùng không hợp lệ!");

            }
            else
            {
                return Ok(model);
            }
        }
        [Route("Update-DanhMuc")]
        [HttpPut]
        public IActionResult PutDanhMuc(DanhMucModel model)
        {
            if (model == null)
            {
                return BadRequest("Dữ liệu người dùng không hợp lệ.");
            }

            var success = _dmBll.Update(model);
            if (!success)
            {
                return NotFound();
            }
            return Ok(model);
        }
        [Route("Delete-DanhMuc")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var success = _dmBll.Delete(id);
            return Ok(success);
        }
        [Route("Get-All-DanhMuc")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<DanhMucModel> list = _dmBll.GetAll();
            return Ok(list);
        }

    }
}
