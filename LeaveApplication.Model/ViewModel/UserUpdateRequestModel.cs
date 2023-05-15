using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveApplication.Model.ViewModel
{
    public class UserUpdateRequestModel
    {
        public string Division { get; set; }
        public string Department { get; set; }
        public string Unit { get; set; }
        public string Branch { get; set; }
        public string Address { get; set; }
    }
}
