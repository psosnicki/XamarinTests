using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXam
{
    public class EcmTask
    {
        public string TaskName { get; set; }
        public string Id { get; set; }
        public string WorkflowName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string WfNameStartDate { get { return String.Format("{0} {1}",WorkflowName,StartDate); } }
        
    }
}
