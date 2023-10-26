using Microsoft.AspNetCore.Mvc;
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
                return Ok(state.Data);

            }
            return Ok(state.Message);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var state = await _admin.GetByIdAsync(id);
            if (state.Code == 200 && state.Data is not null)
            {
                return Ok(state.Data);

            }
            if (state.Code == 500)
            {
                return BadRequest(state.Data);

            }
            return NotFound(state.Message);

        }

    }
}
