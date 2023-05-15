using LeaveApplication.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveApplication.Service.Interface
{
    public interface IRecallInformationService
    {
        Task<BaseResponseModel> CreateRecall(Guid id, RecallRequestModel model);
        Task<bool> ReviewRecall(Guid id, bool isApproved);
        Task<bool> UpdateRecall(Guid id, RecallRequestModel model);
        Task<RecallResponseModel> GetRecallByUserId(Guid userId);

    }
}
