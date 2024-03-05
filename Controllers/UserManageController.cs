using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UserManageAPI.Models;
using UserManageAPI.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManageController : ControllerBase
    {

        private IUserManageService _userManageService;
        public UserManageController(IUserManageService userManageService)
        {
            _userManageService = userManageService;
        }

        // GET: api/<UserManageController>
        [HttpGet("GetCal")]
        public IEnumerable<CalculateResponse> GetCal()
        {
            var response = _userManageService.Calculate();

            return response;
        }

        // GET api/<UserManageController>/5
        [HttpGet]
        public IEnumerable<GetUserResponse> Get([FromQuery] string? SearchName="",double FromAge=0 ,double ToAge=0,int Sex=0)
        {
            var response = _userManageService.GetUser(SearchName, FromAge, ToAge, Sex);


            return response;
        }

        // POST api/<UserManageController>
        [HttpPost]
        public IActionResult Post([FromBody] AddUserRequest body)
        {

            var isAddSuccess = _userManageService.AddUser(body);
            if (isAddSuccess)
                return Ok("新增完成");
            else
                return BadRequest();

        }
    }
}
