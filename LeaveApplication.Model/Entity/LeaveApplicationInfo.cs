using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveApplication.Model.Entity
{
    public class LeaveApplicationInfo
    {
     public Guid Id { get; set; }
     public Guid UserId { get; set; }
     public Guid LeaveTypeInfoId { get; set; }
     public DateTime DateFrom { get; set; }
     public DateTime DateTo { get; set; }
     public double BonusAmount { get; set; }
     public string Description { get; set; }
     public int NoOfDays { get; set; }
     public bool IsReviewed { get; set; }
     public bool IsApproved { get; set; }
     public DateTime CreatedDate { get; set; }
     public DateTime UpdatedDate { get; set; }
    }
}
