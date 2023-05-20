using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveApplication.Model.Entity
{
    public class LeaveTypeInfo: BaseEntity
    {
     public string Name { get; set; }
     public int DaysAllowed { get; set; }
     public bool IsBonusApplicable { get; set; }    
     public bool IsActive { get; set; }
     
    }
}
