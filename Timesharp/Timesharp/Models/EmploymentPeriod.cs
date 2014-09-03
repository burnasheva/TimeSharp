using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Timesharp.Models
{
    public class EmploymentPeriod
    {
        public Employee Employee { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}