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
    public class RecallController : ControllerBase
    {
        private readonly IRecallInformationService _recallInformationService;
        public RecallController(IRecallInformationService recallInformationService)
        {
            _recallInformationService = recallInformationService;
        }

        [HttpPost("CreateRecall")]

        public async Task<IActionResult> CreateRecall(Guid id, RecallRequestModel model)
        {
            var response = await _recallInformationService.CreateRecall(id, model);
            return Ok(response);
        }

        [HttpPost("ReviewRecall")]

        public async Task<IActionResult> ReviewRecall(Guid id, bool isApproved)
        {
            var response = await _recallInformationService.ReviewRecall(id, isApproved);
            return Ok(response);
        }

        [HttpPut("UpdateRecall")]

        public async Task<IActionResult> UpdateRecall(Guid id, RecallRequestModel model)
        {
            var response = await _recallInformationService.UpdateRecall(id, model);
            return Ok(response);
        }

        [HttpGet("GetRecallByUserId")]

        public async Task<IActionResult> GetRecallByUserId(Guid userId)
        {
            var response = await _recallInformationService.GetRecallByUserId(userId);
            return Ok(response);
        }
    }
}
