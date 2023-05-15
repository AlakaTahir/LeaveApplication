using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveApplication.Model.Entity
{
    public class LeaveTypeInfo
    {
     public Guid Id { get; set; }
     public string Name { get; set; }
     public int DaysAllowed { get; set; }
     public bool IsBonusApplicable { get; set; }    
     public bool IsActive { get; set; }
     public DateTime CreatedDate { get; set; }
     public DateTime UpdatedDate { get; set; }

     
    }
}
