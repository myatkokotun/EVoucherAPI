using EVMS.Helpers;
using EVMS.Managers;
using EVMS.Models;
using EVMS.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EVMS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        CMSUserManager usermgr=new CMSUserManager();

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string Username, string Password)
        {
            IActionResult response = Unauthorized();
            TbCmsuser cmsuser= new TbCmsuser();
            cmsuser.Username = Username;
            cmsuser.Password = Password;
            TbCmsuser obj = await usermgr.GetUser(cmsuser);
            if (obj != null)
            {
                JwtAuthenticationHelper jwthelper = new JwtAuthenticationHelper(_config);
                var tokenstr = jwthelper.GenerateJSONWebToken(obj);
                LoginViewModel result = new LoginViewModel();
                result.CmsUser = obj;
                result.JwtAuth = tokenstr;
                response = Ok(result);
            }
            return response;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserObj(int ID)
        {
            TbCmsuser obj = await usermgr.DetailUser(ID);
            if (obj == null) return BadRequest();
            return Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> UpSertCMSUser(TbCmsuser user)
        {
            TbCmsuser obj = await usermgr.UpSertCMSUser(user);
            if (obj == null) return NotFound();
            return Ok(obj);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserList(int page = 1, int pagesize = 10)
        {
            var userlist = await usermgr.UserList(page, pagesize);
            return Ok(userlist);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(int ID)
        {
            string status = await usermgr.DeleteUser(ID);
            return Ok(status);
        }
    }
}
