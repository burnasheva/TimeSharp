using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Timesharp.Models.EmployeeContext;

namespace Timesharp.Models
{
    public class EmploymentPeriod
    {
        public int ID { get; set; }
        public virtual User User { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}