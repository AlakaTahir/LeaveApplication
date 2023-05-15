using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveApplication.Model.Entity
{
    public class RecallInformation
    {
     public Guid Id { get; set; }
     public Guid UserId { get; set; }
     public Guid LeaveApplicationInfoId { get; set; }
     public DateTime DateFrom { get; set; }
     public DateTime DateTo { get; set; }
     public int NoOfDays { get; set; }
     public bool IsReviewed { get; set; }
     public bool IsApproved { get; set; }
     public DateTime CreatedDate { get; set; }
     public DateTime UpdatedDate { get; set; }  
    }
}
