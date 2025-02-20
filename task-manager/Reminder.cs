using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public override void Draw(Graphics g, int x, int y)
        {
            Rectangle rect = new Rectangle(x, y, 300, 100);
            g.FillRectangle(IsViewed ? Brushes.LightGray : Brushes.LightBlue, rect);
            g.DrawRectangle(Pens.Black, rect);

            g.DrawString($"{Title}", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, x + 5, y + 5);
            g.DrawString(Description, new Font("Arial", 9), Brushes.Black, x + 5, y + 25);
            g.DrawString($"Reminder: {SheduledTime:G}", new Font("Arial", 8), Brushes.Black, x + 5, y + 50);
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
