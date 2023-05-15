using LeaveApplication.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveApplication.Service.Interface
{
    public interface ILeaveTypeInformationService
    {
        Task<bool> UpdateLeaveType(Guid id, LeaveTypeRequestModel model);
        Task<bool> LeaveActivation(Guid id, bool isactive);
        Task<LeaveTypeResponseModel> GetLeaveTypeById(Guid id);
        Task<List<LeaveTypeResponseModel>> GetAllConverter();
    }
}
