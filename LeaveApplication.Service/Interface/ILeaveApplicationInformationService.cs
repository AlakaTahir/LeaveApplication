﻿using LeaveApplication.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveApplication.Service.Interface
{
    public interface ILeaveApplicationInformationService
    {
        Task<BaseResponseModel> CreateLeaveApplication(LeaveApplicationRequestModel model);
        Task<bool> ReviewLeave(Guid id, bool isApproved);
        Task<BaseResponseModel> DeleteLeaveApplication(Guid id);
        Task<bool> UpdateLeaveApplication(Guid id, LeaveApplicationRequestModel model);
        Task<LeaveApplicatonResponseModel> GetLeaveByUserId(Guid userId);
    }
}
