using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveApplication.Model.ViewModel
{
    public class LeaveTypeRequestModel
    {
        public string Name { get; set; }
        public int DaysAllowed { get; set; }
        public bool IBonusApplicable { get; set; }
        public bool IsActive { get; set; }

    }
}
