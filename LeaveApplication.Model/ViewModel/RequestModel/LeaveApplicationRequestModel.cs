using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveApplication.Model.ViewModel
{
    public class LeaveApplicationRequestModel
    {
        public Guid UserId { get; set; }
        public Guid LeaveTypeInfoId { get; set; }
        public DateTime DateFrom { get; set; }
        public double BonusAmount { get; set; }
        public string Description { get; set; }
        public int NoOfDays { get; set; }
        
    }
}
