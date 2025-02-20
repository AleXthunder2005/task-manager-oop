using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_manager
{
    public abstract class Task
    {
        private string m_title;
        private string m_description;
        private int m_taskId;

        private static int m_idCounter = 0;

        public Task(string title = "new task", string description = "about task") {
            Title = title;
            Description = description;
            m_taskId = m_idCounter++;
        }


        //properties
        public string Title {
            get { return m_title; }
            set { m_title = value; }
        }
        public string Description {
            get { return m_description; }
            set { m_description = value; }
        }

        public int TaskID {
            get { return m_taskId; }
        }
    }
}
