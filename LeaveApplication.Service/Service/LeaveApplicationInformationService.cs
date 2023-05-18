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
    public class LeaveApplicationInformationService : ILeaveApplicationInformationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LeaveApplicationInformationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponseModel> CreateLeaveApplication(Guid id, LeaveApplicationRequestModel model)
        {
            var leave = _unitOfWork.GetRepository<LeaveApplicationInfo>().GetFirstOrDefault(predicate: x => x.Id == id);
            if (leave == null)
            {
                var newleave = new LeaveApplicationInfo();
                newleave.Id = Guid.NewGuid();
                newleave.UserId = model.UserId;
                newleave.LeaveTypeInfoId = model.LeaveTypeInfoId;
                newleave.BonusAmount = model.BonusAmount;
                newleave.NoOfDays = model.NoOfDays;
                newleave.BonusAmount = model.BonusAmount;
                newleave.DateFrom = model.DateFrom;
                newleave.DateTo = model.DateTo;
                newleave.Description = model.Description;
                newleave.CreatedDate = DateTime.Now;

                _unitOfWork.GetRepository<LeaveApplicationInfo>().Insert(newleave);
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

        public async Task<bool> ReviewLeave(Guid id, bool isApproved)
        {
            var leave = _unitOfWork.GetRepository<LeaveApplicationInfo>().GetFirstOrDefault(predicate: x => x.Id == id);
            if (leave != null)
            {
                leave.IsApproved = isApproved;
                leave.IsReviewed = true;
                leave.UpdatedDate = DateTime.Now;

                _unitOfWork.GetRepository<LeaveApplicationInfo>().Update(leave);
                await _unitOfWork.SaveChangesAsync();
            }
            return false;
        }

        public async Task<BaseResponseModel> DeleteLeaveApplication(Guid id)
        {
            var leave = _unitOfWork.GetRepository<LeaveApplicationInfo>().GetFirstOrDefault(predicate: x => x.Id == id);
            if (leave != null)
            {
                _unitOfWork.GetRepository<LeaveApplicationInfo>().Delete(leave);
                await _unitOfWork.SaveChangesAsync();

                return new BaseResponseModel
                {
                    Message = "Deleted Successfully",
                    Status = true,
                };
            }
            return null;


        }

        public async Task<bool> UpdateLeaveApplication(Guid id, LeaveApplicationRequestModel model)
        {
            var leave = _unitOfWork.GetRepository<LeaveApplicationInfo>().GetFirstOrDefault(predicate: x => x.Id == id);
            if (leave != null)
            {
                leave.NoOfDays = model.NoOfDays;
                leave.DateFrom = model.DateFrom;
                leave.DateTo = model.DateTo;
                leave.BonusAmount = model.BonusAmount;
                leave.UpdatedDate = DateTime.Now;

                _unitOfWork.GetRepository<LeaveApplicationInfo>().Update(leave);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            return false;

        }

        public async Task<LeaveApplicatonResponseModel> GetApplicationByUserId(Guid userId)
        {
            var leave = _unitOfWork.GetRepository<LeaveApplicationInfo>().GetFirstOrDefault(predicate: x => x.UserId == userId);
            if (leave != null)
            {

                return new LeaveApplicatonResponseModel
                {


                    DateFrom = DateTime.Now,
                    DateTo = DateTime.Now,
                    NoOfDays = leave.NoOfDays,
                    BonusAmount = leave.BonusAmount,
                };
            }
            else
            {
                return null;
            };
        }


    }
}
