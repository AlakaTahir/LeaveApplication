using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveApplication.Model.ViewModel
{
    public class LeaveTypeResponseModel
    {
        public string Name { get; set; }
        public int DaysAllowed { get; set; }
        public bool IsBonusApplicable { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
