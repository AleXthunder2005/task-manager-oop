using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


        public override void Draw(Graphics g, int x, int y)
        {
            Rectangle rect = new Rectangle(x, y, 300, 100);
            g.DrawRectangle(Pens.Black, rect);

            g.DrawString($"{Title}", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, x + 5, y + 5);
            g.DrawString(Description, new Font("Arial", 9), Brushes.Black, x + 5, y + 25);
            g.DrawString($"Start: {StartDate:G}", new Font("Arial", 8), Brushes.Black, x + 5, y + 45);
            g.DrawString($"Deadline: {DeadlineDate:G}", new Font("Arial", 8), Brushes.Black, x + 5, y + 65);
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
