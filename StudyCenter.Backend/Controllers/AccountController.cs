using Microsoft.AspNetCore.Mvc;
using StudyCenter.Backend.Models;
using StudyCenter.Backend.Repositories.Account;

namespace StudyCenter.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController:ControllerBase
    {
        private readonly IAdminAccountService _admin;

        public AccountController(IAdminAccountService admin)
        {
            _admin = admin;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllAdminData()
        {
            var state = await _admin.GetAllDataAsync();
            if (state.Code == 200 && state.Data is not null) 
            {
                return StatusCode(StatusCodes.Status200OK, state);

            }
            else if(state.Code == 500 && state.Data is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, state);

            }
            return StatusCode(StatusCodes.Status404NotFound, state);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var state = await _admin.GetByIdAsync(id);
            if (state.Code == 200 && state.Data is not null)
            {
                return StatusCode(StatusCodes.Status200OK, state);

            }
            if (state.Code == 500 && state.Data is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, state);

            }
            return StatusCode(StatusCodes.Status404NotFound,state);

        }
        [HttpPost]
        public async Task<IActionResult> SignUp([FromForm]Admin admin)
        {
            var res = await _admin.SignUpAsync(admin);
            if (res.Code == 302 && res.Data is not null )
            {
                return StatusCode(StatusCodes.Status302Found, res.Data);

            }
            else if(res.Code == 201 && res.Data is not null) 
            {
                return StatusCode(StatusCodes.Status201Created, res.Data);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, res.Data);

        }

    }
}
