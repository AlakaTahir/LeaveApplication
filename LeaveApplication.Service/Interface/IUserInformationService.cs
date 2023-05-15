using LeaveApplication.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveApplication.Service.Interface
{
    public interface IUserInformationService
    {
        public  Task<BaseResponseModel> CreateUser(UserInformationRequestModel model);
        public  Task<BaseResponseModel> UpdateUser(Guid id, UserUpdateRequestModel model);
        Task<bool> ActivateUser(Guid id);
        Task<bool> DeactivateUser(Guid id);
        Task<UserInformationResponseModel> GetUserById(Guid id);





    }
}
