using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_manager
{
    class Reminder : Task
    {
        private DateTime m_sheduledTime;
        private bool m_isViewed;

        public Reminder(DateTime sheduledTime, string title = "new task", string description = "about task") : base(title, description)
        {
            SheduledTime = sheduledTime;
            IsViewed = false;
        }


        //properties
        public DateTime SheduledTime
        {
            get { return m_sheduledTime; }
            set { m_sheduledTime = value; }
        }
 
        public bool IsViewed
        {
            get { return m_isViewed; }
            set { m_isViewed = value; }
        }
    }
}
