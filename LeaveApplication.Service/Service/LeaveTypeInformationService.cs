using Arch.EntityFrameworkCore.UnitOfWork;
using LeaveApplication.Model.Entity;
using LeaveApplication.Model.ViewModel;
using LeaveApplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveApplication.Service.Service
{
    public class LeaveTypeInformationService : ILeaveTypeInformationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LeaveTypeInformationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateLeaveType(Guid id,LeaveTypeRequestModel model)
        {
            var checkType = await _unitOfWork.GetRepository<LeaveTypeInfo>().GetFirstOrDefaultAsync(predicate: x => x.Name.ToLower().Contains(model.Name.ToLower()));
            if(checkType == null)
            {
                var newLeaveTypeInfo = new LeaveTypeInfo();
                newLeaveTypeInfo.Name = model.Name;
                newLeaveTypeInfo.DaysAllowed = model.DaysAllowed;
                newLeaveTypeInfo.IsBonusApplicable = false;
                newLeaveTypeInfo.IsActive = true;
                newLeaveTypeInfo.CreatedDate = DateTime.Now;

                _unitOfWork.GetRepository<LeaveTypeInfo>().Insert(newLeaveTypeInfo);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            
            return false;
            
        }
        public async Task<bool> UpdateLeaveType (Guid id, LeaveTypeRequestModel model)
        {
            var CheckType = _unitOfWork.GetRepository<LeaveTypeInfo>().GetFirstOrDefault(predicate: x => x.Id == id);
            if (CheckType != null)
            {
                CheckType.Name = model.Name;
                CheckType.DaysAllowed = model.DaysAllowed;
                CheckType.IsBonusApplicable = true;

                _unitOfWork.GetRepository<LeaveTypeInfo>().Update(CheckType);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            return false;

        }

        public async Task<bool> LeaveActivation(Guid id,bool isactive)
        {

            var CheckType = _unitOfWork.GetRepository<LeaveTypeInfo>().GetFirstOrDefault(predicate: x => x.Id == id);
            if (CheckType != null)
            {
                CheckType.IsActive = isactive;
                CheckType.UpdatedDate = DateTime.Now;


                _unitOfWork.GetRepository<LeaveTypeInfo>().Update(CheckType);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            return false;

        }
        public async Task<LeaveTypeResponseModel> GetLeaveTypeById(Guid id)
        {
            var getLeave = _unitOfWork.GetRepository<LeaveTypeInfo>().GetFirstOrDefault(predicate: y => y.Id == id);
            if (getLeave != null)
            {
               
                return new LeaveTypeResponseModel
                {
                    
                    Name = getLeave.Name,
                    DaysAllowed= getLeave.DaysAllowed,
                    IsBonusApplicable = getLeave.IsBonusApplicable,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };
            }
            else
            {
                return null;
            };
        }

        public async Task<List<LeaveTypeResponseModel>> GetAllLeaveType()
        {
            var leaveTypes = _unitOfWork.GetRepository<LeaveTypeInfo>().GetAll().Where(predicate: x => x.IsActive).ToList();
            if (leaveTypes.Count != 0)
            {
                var response = new List<LeaveTypeResponseModel>();
                foreach (var leaveType in leaveTypes)
                {
                    var singleModel = new LeaveTypeResponseModel();
                    singleModel.Name = leaveType.Name;
                    singleModel.DaysAllowed = leaveType.DaysAllowed;
                    singleModel.IsBonusApplicable = leaveType.IsBonusApplicable;
                    singleModel.CreatedDate = DateTime.Now;

                    response.Add(singleModel);

                }
                return response;

            }
            
           return null;
        }






    }
}
