using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveApplication.Model.Entity
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
