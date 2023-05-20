using LeaveApplication.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveApplication.Service.Interface
{
    public interface IAccessTypeInformationService
    {
        Task<BaseResponseModel> CreateAccessType(Guid id, AccessTypeRequestModel model);
        Task<BaseResponseModel> UpdateAccessType(Guid id, AccessTypeRequestModel model);
        Task<BaseResponseModel> DeleteAccessType(Guid id);
        Task<bool> AccessTypeActivation(Guid id, bool isactive);
        Task<AccessTypeResponseModel> GetAccessTypeById(Guid id);
        Task<List<AccessTypeResponseModel>> GetAllAccessType();




    }
}
