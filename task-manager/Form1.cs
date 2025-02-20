using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using static task_manager.PriorityTask;

namespace task_manager
{
    public partial class MainForm: Form
    {
        private TaskList<Task> m_tasks = new TaskList<Task>();

        public MainForm()
        {
            InitializeComponent();
            this.mainContentPanel.Paint += new PaintEventHandler(MainFormPaint);


            m_tasks.AddTask(new Reminder(DateTime.Now.AddHours(2), "Call mom", "Call at 6:00 PM"));
            m_tasks.AddTask(new SimpleTask(DateTime.Now, DateTime.Now.AddDays(1), "Prepare report", "Send by tomorrow"));
            m_tasks.AddTask(new PriorityTask(DateTime.Now, DateTime.Now.AddHours(5), t_priority.High, "very very urgent meeting", "Discuss the project"));
            m_tasks.AddTask(new PriorityTask(DateTime.Now, DateTime.Now.AddHours(5), t_priority.Low, "urgent meeting", "Discuss the project"));
            m_tasks.AddTask(new ProgressTask(300, DateTime.Now, DateTime.Now.AddDays(7), "Read a book", "Read 300 pages"));
        }

        private void MainFormPaint(object sender, PaintEventArgs e)
        {
            int y = 10;

            Node<Task> current = m_tasks.Head;
            while (current != null)
            {
                current.Data.Draw(e.Graphics, 20, y);
                y += 110;
                current = current.Next;
            }
        }

    }
}
