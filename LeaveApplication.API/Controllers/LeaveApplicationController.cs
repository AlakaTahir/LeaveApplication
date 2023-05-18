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
    public class LeaveApplicationController : ControllerBase
    {
        private readonly ILeaveApplicationInformationService _leaveApplicationInformationservice;
        public LeaveApplicationController(ILeaveApplicationInformationService leaveApplicationInformationservice)
        {
            _leaveApplicationInformationservice = leaveApplicationInformationservice;
        }

        [HttpPost("CreateLeaveApplication")]

        public async Task<IActionResult> CreateLeaveApplication(Guid id, LeaveApplicationRequestModel model)
        {
            var response = await _leaveApplicationInformationservice.CreateLeaveApplication(id, model);
            return Ok(response);
        }

        [HttpPost("LeaveReview")]
        public async Task<IActionResult> ReviewLeave(Guid id, bool isApproved)
        {
            var response = await _leaveApplicationInformationservice.ReviewLeave(id, isApproved);
            return Ok(response);
        }

        [HttpDelete("DeleteLeaveApplication")]
        public async Task<IActionResult> DeleteLeaveApplication(Guid id)
        {
            var response = await _leaveApplicationInformationservice.DeleteLeaveApplication(id);
            return Ok(response);
        }


        [HttpGet("GetApplicationByUserId")]
        public async Task<IActionResult> GetApplicationByUserId(Guid userId)
        {
            var response = await _leaveApplicationInformationservice.GetApplicationByUserId(userId);
            return Ok(response);
        }
    }
}
