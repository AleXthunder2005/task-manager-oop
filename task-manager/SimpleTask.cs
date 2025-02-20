using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_manager
{
    class SimpleTask : Task
    {
        private DateTime m_startDate;
        private DateTime m_deadlineDate;
        private bool m_isCompleted;

        public SimpleTask(DateTime startDate, DateTime deadlineDate, string title = "new task", string description = "about task") : base(title, description) {
            StartDate = startDate;
            DeadlineDate = deadlineDate;
            IsCompleted = false;
        }


        //properties
        public DateTime StartDate {
            get { return m_startDate; }
            set { m_startDate = value; }
        }
        public DateTime DeadlineDate
        {
            get { return m_deadlineDate; }
            set { m_deadlineDate = value; }
        }
        public bool IsCompleted
        {
            get { return m_isCompleted; }
            set { m_isCompleted = value; }
        }
    }
}
