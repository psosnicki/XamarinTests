using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppXam
{
    public class TasksMenuItem : MenuItem
    {
        public int DeadlineTasks { get; set; }
        public int OverdueTasks { get; set; }
        public int NormalTasks { get; set; }
    }
}
