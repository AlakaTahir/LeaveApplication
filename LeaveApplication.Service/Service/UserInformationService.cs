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
    public class UserInformationService : IUserInformationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserInformationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponseModel> CreateUser(UserInformationRequestModel model)
        {
            var user = _unitOfWork.GetRepository<UserInfo>().GetFirstOrDefault(predicate: x=> x.Email == model.Email);
            if (user == null)
            {
                var newUser = new UserInfo();
                newUser.Id = Guid.NewGuid();
                newUser.Name = model.Name;
                newUser.Email = model.Email;
                newUser.PhoneNumber = model.PhoneNumber;
                newUser.CreatedDate = DateTime.Now;

                _unitOfWork.GetRepository<UserInfo>().Insert(newUser);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponseModel
                {
                    Message = "User Successfully Registered",
                    Status = true
                };
            }
            return new BaseResponseModel
            {
                Message = "User Already Exist",
                Status = false
            };
        }
        public async Task<BaseResponseModel> UpdateUser(Guid id, UserUpdateRequestModel model)
        {
            var user = _unitOfWork.GetRepository<UserInfo>().GetFirstOrDefault(predicate: x => x.Id == id);
            if (user != null)
            {
                user.Address = model.Address;
                user.Department = model.Department;
                user.Division = model.Division;
                user.Unit = model.Unit;
                user.Branch = model.Branch;
                user.UpdatedDate = DateTime.Now;

                _unitOfWork.GetRepository<UserInfo>().Update(user);
                await _unitOfWork.SaveChangesAsync();

                return new BaseResponseModel
                {
                    Message = "Updated Successfully",
                    Status = true
                };
            }
            return new BaseResponseModel
            {
                Message = "Unsuccessful",
                Status = false

            };
        }
        public async Task<bool>ActivateUser(Guid id)
        {
            var user = _unitOfWork.GetRepository<UserInfo>().GetFirstOrDefault(predicate: x => x.Id == id);
            if (user != null)
            {
              user.IsActive = true;
              user.UpdatedDate= DateTime.Now;

             _unitOfWork.GetRepository<UserInfo>().Update(user);
             await _unitOfWork.SaveChangesAsync();
            }
            return false;
        }
        public async Task<bool>DeactivateUser(Guid id)
        {
            var user = _unitOfWork.GetRepository<UserInfo>().GetFirstOrDefault(predicate: x => x.Id == id);
            if (user != null)
            {
                user.IsActive= false;
                user.UpdatedDate= DateTime.Now;

                _unitOfWork.GetRepository<UserInfo>().Update(user);
                await _unitOfWork.SaveChangesAsync();
            }
            return true;
        }
        public async Task<UserInformationResponseModel> GetUserById(Guid id)
        {
            var user = _unitOfWork.GetRepository<UserInfo>().GetFirstOrDefault(predicate: y => y.Id == id);
            if (user != null)
            {

                return new UserInformationResponseModel
                {

                    Name = user.Name,
                    PhoneNumber = user.PhoneNumber,
                    Email  = user.Email,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };
            }
            else
            {
                return null;
            };
        }

    }
}
