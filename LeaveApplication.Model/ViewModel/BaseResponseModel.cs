using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveApplication.Model.ViewModel
{
    public class BaseResponseModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string Note { get; set; }
    }
}
