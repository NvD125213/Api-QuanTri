using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModel;
using BLL.Interface;

namespace API_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaCungCapController : ControllerBase
    {
        private INhaCungCapBLL _nccBLL;
        public NhaCungCapController(INhaCungCapBLL nccBLL)
        {
            _nccBLL = nccBLL;
        }
        [Route("Create-NCC-by-Admin")]
        [HttpPost]
        public IActionResult CreateNCC([FromBody] NhaCungCapModel model)
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

        [Route("Update-NCC-by-Admin")]
        [HttpPut]
        public IActionResult PutNCC(NhaCungCapModel model)
        {
            if (model == null)
            {
                return BadRequest("Dữ liệu người dùng không hợp lệ.");
            }

            var success = _nccBLL.Update(model);
            if (!success)
            {
                return NotFound();
            }
            return Ok(model);
        }
        [Route("Delete-NCC-by-Admin")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var success = _nccBLL.Delete(id);
            return Ok(success);
        }
        [Route("GetAll-NCC")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<NhaCungCapModel> list = _nccBLL.GetAll();
            return Ok(list);
        }
        [Route("Get-NCC-by-Admin")]
        [HttpGet]
        public NhaCungCapModel GetDatabyID(int id)
        {
            return _nccBLL.GetNhaCCByID(id);
        }


    }
}
