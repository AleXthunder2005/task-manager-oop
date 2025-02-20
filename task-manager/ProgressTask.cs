using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_manager
{
    class ProgressTask : SimpleTask
    {
        private int m_goalCount;
        private int m_currCount;


        public ProgressTask(int goalCount, DateTime startDate, DateTime deadlineDate, string title = "new task", string description = "about task") : base(startDate, deadlineDate, title, description)
        {
            GoalCount = goalCount;
            CurrCount = 0;
        }

        //properties
        public int GoalCount
        {
            get { return m_goalCount; }
            set { m_goalCount = value; }
        }

        public int CurrCount
        {
            get { return m_currCount; }
            set { m_currCount = value; }
        }
    }
}
