using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveApplication.Model.ViewModel
{
    public class RecallRequestModel
    {
        public Guid LeaveApplicationId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int NoOfDays { get; set; }
    }
}

