﻿using LeaveApplication.Model.ViewModel;
using LeaveApplication.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LeaveApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly ILeaveTypeInformationService _leaveTypeInformationService;
        public LeaveTypeController(ILeaveTypeInformationService leaveTypeInformationService)
        {
            _leaveTypeInformationService = leaveTypeInformationService;
        }

        [HttpPost("CreateLeaveType")]

        public async Task<IActionResult> CreateLeaveType(Guid id, LeaveTypeRequestModel model)
        {
            var response = await _leaveTypeInformationService.CreateLeaveType(id, model);
            return Ok(response);
        }

        [HttpPut("UpdateLeaveType")]

        public async Task<IActionResult> UpdateLeaveType(Guid id, LeaveTypeRequestModel model)
        {
            var response = await _leaveTypeInformationService.UpdateLeaveType(id, model);
            return Ok(response);
        }

        [HttpPost("LeaveActivation")]

        public async Task<IActionResult> LeaveActivation(Guid id, bool isactive)
        {
            var response = await _leaveTypeInformationService.LeaveActivation(id, isactive);
            return Ok(response);
        }

        [HttpGet("GetLeaveTypeById")]

        public async Task<IActionResult> GetLeaveTypeById(Guid id)
        {
            var response = await _leaveTypeInformationService.GetLeaveTypeById(id);
            return Ok(response);
        }

        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAllLeave()
        {
            var response = await _leaveTypeInformationService.GetAllLeave();
            return Ok(response);
        }
    }


        
    
}