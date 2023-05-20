using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveApplication.Model.Entity
{
    public class AccessTypeInfo: BaseEntity
    {
     public string Name { get; set; }
     public string Description { get; set; }
     public bool IsActive { get; set; }
    }
}
