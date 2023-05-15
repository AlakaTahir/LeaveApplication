using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveApplication.Model.Entity
{
    public class AccessTypeInfo
    {
     public Guid Id { get; set; }
     public string Name { get; set; }
     public string Description { get; set; }
     public DateTime CreatedDate { get; set; }
     public DateTime UpdatedDate { get; set; }
     public bool IsActive { get; set; }
    }
}
