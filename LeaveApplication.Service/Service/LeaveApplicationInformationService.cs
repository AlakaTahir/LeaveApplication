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

        public async Task<BaseResponseModel> CreateLeaveApplication(LeaveApplicationRequestModel model)
        {
            var user = _unitOfWork.GetRepository<UserInfo>().GetFirstOrDefault(predicate:x=> x.Id == model.UserId);  
            if (user != null)
            {
                var leavetype = _unitOfWork.GetRepository<LeaveTypeInfo>().GetFirstOrDefault(predicate: x => x.Id == model.LeaveTypeInfoId && x.IsActive == true);
                if (leavetype != null)
                {

                    if (model.NoOfDays > 0 && leavetype.DaysAllowed >= model.NoOfDays)
                    {

                        if (model.DateFrom > DateTime.Now)
                        {
                            if (!leavetype.IsBonusApplicable && model.BonusAmount > 0)
                            {
                                return new BaseResponseModel
                                {
                                    Message = "Bonus is not applicable",
                                    Status = false
                                };
                            }
                            var newleavetype = new LeaveApplicationInfo();
                            newleavetype.Id = Guid.NewGuid();
                            newleavetype.UserId = model.UserId;
                            newleavetype.LeaveTypeInfoId = model.LeaveTypeInfoId;
                            newleavetype.BonusAmount = model.BonusAmount;
                            newleavetype.NoOfDays = model.NoOfDays;
                            newleavetype.DateFrom = model.DateFrom;
                            newleavetype.ResumptionDate = AddBusinessDays(model.DateFrom, model.NoOfDays + 1);
                            newleavetype.DateTo = AddBusinessDays(model.DateFrom, model.NoOfDays);
                            newleavetype.Description = model.Description;
                            newleavetype.CreatedDate = DateTime.Now;

                            _unitOfWork.GetRepository<LeaveApplicationInfo>().Insert(newleavetype);

                            await _unitOfWork.SaveChangesAsync();

                            return new BaseResponseModel
                            {
                                Message = "Leavetype Successfully Created",
                                Status = true
                            };

                        }

                        return new BaseResponseModel
                        {
                            Message = "Date From is not valid",
                            Status = false
                        };
                    }

                    return new BaseResponseModel
                    {
                        Message = "Applied number of days is not valid",
                        Status = false
                    };

                }
               
                return new BaseResponseModel
                {
                    Message = "Leavetype Doesnt exist",
                    Status = false
                };

            }


            return new BaseResponseModel
            {
                Message = "User does not exist",
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
                leave.DateTo = AddBusinessDays(model.DateFrom, model.NoOfDays);
                leave.ResumptionDate = AddBusinessDays(model.DateFrom, model.NoOfDays+1);
                leave.BonusAmount = model.BonusAmount;
                leave.UpdatedDate = DateTime.Now;

                _unitOfWork.GetRepository<LeaveApplicationInfo>().Update(leave);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            return false;

        }

        public async Task<LeaveApplicatonResponseModel>GetLeaveByUserId(Guid userId)
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

        private static DateTime AddBusinessDays(DateTime date, int days)
        {
            if (days < 0)
            {
                throw new ArgumentException("days cannot be negative", "days");
            }

            if (days == 0) return date;

            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                date = date.AddDays(2);
                days -= 1;
            }
            else if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                date = date.AddDays(1);
                days -= 1;
            }

            date = date.AddDays(days / 5 * 7);
            int extraDays = days % 5;

            if ((int)date.DayOfWeek + extraDays > 5)
            {
                extraDays += 2;
            }

            return date.AddDays(extraDays);

        }
    }
}

//if (leavetype == null)
//{
//    return new BaseResponseModel
//    {
//        Message = "Leavetype Doesnt exist",
//        Status = false
//    };
//}
//if (model.NoOfDays == 0 || leavetype.DaysAllowed <= model.NoOfDays)
//{
//    return new BaseResponseModel
//    {
//        Message = "Applied number of days is not valid",
//        Status = false
//    };
//}
//if (model.DateFrom <= DateTime.Now)
//{
//    return new BaseResponseModel
//    {
//        Message = "Date From is not valid",
//        Status = false
//    };
//}
//if (!leavetype.IsBonusApplicable && model.BonusAmount > 0)
//{
//    return new BaseResponseModel
//    {
//        Message = "Bonus is not applicable",
//        Status = false
//    };
//}
