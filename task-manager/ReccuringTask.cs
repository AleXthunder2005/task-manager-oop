using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_manager
{
    class ReccuringTask : SimpleTask
    {
        private double m_interval; // в часах

        public ReccuringTask(int interval, DateTime startDate, DateTime deadlineDate, string title = "new task", string description = "about task") : base(startDate, deadlineDate, title, description)
        {
            Interval = interval;
        }

        //properties
        public double Interval
        {
            get { return m_interval; }
            set { m_interval = value; }
        }
    }
}
