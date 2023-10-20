using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModel;
using BLL.Interface;


namespace API_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBLL _userBLL;
        public UserController(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }
        [Route("Create-User-by-Admin")]
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserModel model)
        {
            if(model == null)
            {
                return BadRequest("Dữ liệu người dùng không hợp lệ!");

            }   
            else
            {
                return Ok(model);
            }    
        }

        [Route("Update-User-by-Admin")]
        [HttpPut]
        public IActionResult Put(UserModel model)
        {
            if (model == null)
            {
                return BadRequest("Dữ liệu người dùng không hợp lệ.");
            }

            var success = _userBLL.UpdateUser(model);
            if (!success)
            {
                return NotFound();
            }
            return Ok(model);
        }
        [Route("Delete-User-by-Admin")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var success =_userBLL.DeleteUser(id);
            return Ok(success);
        }
        [Route("Search-user")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten = "";
                if (formData.Keys.Contains("ten") && !string.IsNullOrEmpty(Convert.ToString(formData["ten"]))) { ten = Convert.ToString(formData["ten"]); }
                string email = "";
                if (formData.Keys.Contains("email") && !string.IsNullOrEmpty(Convert.ToString(formData["email"]))) { email = Convert.ToString(formData["email"]); }
                long total = 0;
                var data = _userBLL.Search(page, pageSize, out total, ten, email);
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
