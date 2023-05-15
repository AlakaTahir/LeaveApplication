using LeaveApplication.Model.ViewModel;
using LeaveApplication.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LeaveApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveInformationController : ControllerBase
    {
        private readonly IUserInformationService _userInformationService;
        public LeaveInformationController(IUserInformationService userInformationService)
        {
            _userInformationService = userInformationService;
        }

        [HttpPost("CreateUser")]

        public async Task<IActionResult> CreateUser(UserInformationRequestModel model)
        {
            var response = await _userInformationService.CreateUser(model);
            return Ok(response);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(Guid id, UserUpdateRequestModel model)
        {
            var response = await _userInformationService.UpdateUser(id, model);
            return Ok(response);
        }
        [HttpPost("ActivateUser")]
        public async Task<IActionResult> ActivateUser(Guid id)
        {
            var response = await _userInformationService.ActivateUser(id);
            return Ok(response);
        }
        [HttpGet("DeActivate")]
        public async Task<IActionResult> DeactivateUser(Guid id)
        {
            var response = await _userInformationService.DeactivateUser(id);
            return Ok(response);

        }
        [HttpGet("GetUserById")]
        public async Task<IActionResult>  GetUserById(Guid id)
        {
            var response = await _userInformationService.GetUserById(id);
            return Ok(response);
        }
        
    }
}
