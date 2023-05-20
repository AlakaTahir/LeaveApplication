using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveApplication.Model.Entity
{
    public class UserInfo: BaseEntity
    {
     public Guid? AccessTypeInfoId { get; set; }
     public string Name { get; set; }
     public string Email { get; set; }
     public string PhoneNumber { get; set; }
     public string Division { get; set; }
     public string Department { get; set; }
     public string Unit { get; set; }
     public string Branch { get; set; }
     public string Address { get; set; }
     public DateTime? ApprovedDate { get; set; }
     public bool IsActive { get; set; }
     
    }
}
