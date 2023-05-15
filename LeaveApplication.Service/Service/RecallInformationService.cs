using Arch.EntityFrameworkCore.UnitOfWork;
using LeaveApplication.Model.Entity;
using LeaveApplication.Model.ViewModel;
using LeaveApplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveApplication.Service.Service
{

    public class RecallInformationService : IRecallInformationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RecallInformationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponseModel> CreateRecall(Guid id, RecallRequestModel model)
        {
            var recall = _unitOfWork.GetRepository<RecallInformation>().GetFirstOrDefault(predicate: x => x.Id == id);
            if (recall == null)
            {
                var newrecall = new RecallInformation();
                newrecall.Id = Guid.NewGuid();
                newrecall.DateFrom = model.DateFrom;
                newrecall.DateTo = model.DateTo;
                newrecall.NoOfDays = model.NoOfDays;
                newrecall.CreatedDate = DateTime.Now;

                _unitOfWork.GetRepository<RecallInformation>().Insert(newrecall);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponseModel
                {
                    Message = "Access Successfully Created",
                    Status = true
                };
            }
            return new BaseResponseModel
            {
                Message = "AccessType already exist",
                Status = false
            };
        }

        public async Task<bool> ReviewRecall(Guid id, bool isApproved)
        {
            var recall = _unitOfWork.GetRepository<RecallInformation>().GetFirstOrDefault(predicate: x => x.Id == id);
            if (recall != null)
            {
                recall.IsApproved = isApproved;
                recall.IsReviewed = true;
                recall.UpdatedDate = DateTime.Now;

                _unitOfWork.GetRepository<RecallInformation>().Update(recall);
                await _unitOfWork.SaveChangesAsync();
            }
            return false;
        }

        public async Task<bool> UpdateRecall(Guid id, RecallRequestModel model)
        {
            var recall = _unitOfWork.GetRepository<RecallInformation>().GetFirstOrDefault(predicate: x => x.Id == id);
            if (recall != null)
            {
                recall.NoOfDays = model.NoOfDays;
                recall.DateFrom = DateTime.Now;
                recall.DateTo = DateTime.Now;
                recall.UpdatedDate = DateTime.Now;

                _unitOfWork.GetRepository<RecallInformation>().Update(recall);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            return false;

        }

        public async Task<RecallResponseModel> GetRecallByUserId(Guid userId)
        {
            var recall= _unitOfWork.GetRepository<RecallInformation>().GetFirstOrDefault(predicate: x => x.UserId == userId);
            if (recall != null)
            {

                return new RecallResponseModel
                {


                    DateFrom = DateTime.Now,
                    DateTo = DateTime.Now,
                    NoOfDays = recall.NoOfDays,
                };
            }
            else
            {
                return null;
            };
        }

    }   
}