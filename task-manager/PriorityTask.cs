using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_manager
{
    class PriorityTask : SimpleTask
    {
        //datatypes
        public enum t_priority
        {
            Low,
            Medium,
            High
        };

        private t_priority m_priority;
        public new static string taskTypeName = "Priority task";

        public PriorityTask( DateTime startDate, DateTime deadlineDate, t_priority priority = t_priority.Low, string title = "new task", string description = "about task") : base(startDate, deadlineDate, title, description)
        {
            Priority = priority;
        }

        public override void Draw(Graphics g, int x, int y)
        {
            Color priorityColor;
            switch (Priority)
            {
                case t_priority.Low:
                    priorityColor = Color.LightGreen;
                    break;
                case t_priority.Medium:
                    priorityColor = Color.LightYellow;
                    break;
                case t_priority.High:
                    priorityColor = Color.LightCoral;
                    break;
                default:
                    priorityColor = Color.White;
                    break;
            }

            Rectangle rect = new Rectangle(x, y, 300, 100);
            g.FillRectangle(new SolidBrush(priorityColor), rect);
            g.DrawRectangle(Pens.Black, rect);

            base.Draw(g, x, y);
        }

        //properties
        public t_priority Priority
        {
            get { return m_priority; }
            set { m_priority = value; }
        }


    }
}
