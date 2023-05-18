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
    public class AccessTypeController : ControllerBase
    {
        private readonly IAccessTypeInformationService _accessTypeInformationService;
        public AccessTypeController(IAccessTypeInformationService accessTypeInformationService)
        {
            _accessTypeInformationService = accessTypeInformationService;
        }

        [HttpPost("CreateAccessType")]

        public async Task<IActionResult> CreateAccessType(Guid id, AccessTypeRequestModel model)
        {
            var response = await _accessTypeInformationService.CreateAccessType(id, model);
            return Ok(response);
        }
        
        [HttpPost("UpdateAccessType")]

        public async Task<IActionResult> UpdateAccessType(Guid id, AccessTypeRequestModel model)
        {
            var response = await _accessTypeInformationService.UpdateAccessType(id, model);
            return Ok(response);
        }
        
        [HttpDelete("DeleteAccessType")]

        public async Task<IActionResult> DeleteAccessType(Guid id)
        {
            var response = await _accessTypeInformationService.DeleteAccessType(id);
            return Ok(response);
        }

        [HttpPost("ActivateAccessType")]

        public async Task<IActionResult> AccessTypeActivation(Guid id, bool isactive)
        {
            var response = await _accessTypeInformationService.AccessTypeActivation(id, isactive);
            return Ok(response);
        }

        [HttpGet("GetAccessTypeById")]

        public async Task<IActionResult> GetAccessTypeById(Guid id)
        {
            var response = await _accessTypeInformationService.GetAccessTypeById(id);
            return Ok(response);
        }
        
        [HttpGet("GetAccessTypeById")]

        public async Task<IActionResult> GetAllAccessType()
        {
            var response = await _accessTypeInformationService.GetAllAccessType();
            return Ok(response);
        }


    }
}
