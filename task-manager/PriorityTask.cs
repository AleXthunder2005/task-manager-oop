using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_manager
{
    class PriorityTask : SimpleTask
    {
        private t_priority m_priority; 

        public PriorityTask( DateTime startDate, DateTime deadlineDate, t_priority priority = t_priority.low, string title = "new task", string description = "about task") : base(startDate, deadlineDate, title, description)
        {
            Priority = priority;
        }

        //properties
        public t_priority Priority
        {
            get { return m_priority; }
            set { m_priority = value; }
        }

        //datatypes
        public enum t_priority 
        {
            low, 
            medium, 
            high
        };
    }
}
