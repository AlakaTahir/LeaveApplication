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
    public class AccessTypeInformationService : IAccessTypeInformationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccessTypeInformationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponseModel> CreateAccessType(Guid id,AccessTypeRequestModel model)
        {
            var access = _unitOfWork.GetRepository<AccessTypeInfo>().GetFirstOrDefault(predicate: x => x.Id == id);
            if (access == null)
            {
                var newaccess = new AccessTypeInfo();
                newaccess.Id = Guid.NewGuid();
                newaccess.Name = model.Name;
                newaccess.Description= "Manage Access Type";
                newaccess.CreatedDate = DateTime.Now;

                _unitOfWork.GetRepository<AccessTypeInfo>().Insert(newaccess);
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

        public async Task<BaseResponseModel> UpdateAccessType(Guid id, AccessTypeRequestModel model)
        {
            var access = _unitOfWork.GetRepository<UserInfo>().GetFirstOrDefault(predicate: x => x.Id == id);
            if (access != null)
            {
                access.Name = model.Name;
                access.UpdatedDate = DateTime.Now;

                _unitOfWork.GetRepository<UserInfo>().Update(access);
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

        public  async Task<BaseResponseModel> DeleteAccessType(Guid id)
        {
            var access = _unitOfWork.GetRepository<AccessTypeInfo>().GetFirstOrDefault(predicate: x => x.Id == id);
            if (access != null)
            {
                 _unitOfWork.GetRepository<AccessTypeInfo>().Delete(access);
                 await _unitOfWork.SaveChangesAsync();

                return new BaseResponseModel
                {
                    Message = "Deleted Successfully",
                    Status = true,
                };
            }
            return null;
                        
                       
        }
        public async Task<bool> AccessTypeActivation(Guid id, bool isactive)
        {

            var access = _unitOfWork.GetRepository<AccessTypeInfo>().GetFirstOrDefault(predicate: x => x.Id == id);
            if (access != null)
            {
                access.IsActive = isactive;
                access.UpdatedDate = DateTime.Now;


                _unitOfWork.GetRepository<AccessTypeInfo>().Update(access);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            return false;

        }
        public async Task<AccessTypeResponseModel> GetAccessTypeById(Guid id)
        {
            var accessType = _unitOfWork.GetRepository<AccessTypeInfo>().GetFirstOrDefault(predicate: y => y.Id == id);
            if (accessType != null)
            {

                return new AccessTypeResponseModel
                {

                    Name = accessType.Name,
                    Description= accessType.Description,
                    CreatedDate = DateTime.Now,
                    
                };
            }
            else
            {
                return null;
            };
        }

        public List<AccessTypeResponseModel> GetAllConverter()
        {
            var accessTypes = _unitOfWork.GetRepository<AccessTypeInfo>().GetAll().ToList();
            if (accessTypes.Count != 0)
            {
                var response = new List<AccessTypeResponseModel>();
                foreach (var accessType in accessTypes)
                {
                    var singleModel = new AccessTypeResponseModel();
                    singleModel.Name = accessType.Name;
                    singleModel.Description = accessType.Description;
                    singleModel.CreatedDate = DateTime.Now;

                    response.Add(singleModel);

                }
                return response;

            }

            return null;
        }
    }
}
