using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_manager
{
    public abstract class Task
    {
        private string _title;
        private string _description;
        private int _taskId;

        public static int _idCounter;

        static Task() 
        {
            _idCounter = 0;
        }

        public Task() { }
        public Task (TaskBuilder builder) {
            Title = builder.Title;
            Description = builder.Description;

            _taskId = _idCounter++;
        }

        public abstract void Draw(Graphics g, DrawOptions options);

        protected abstract void SetOptions();
        //properties
        public string Title {
            get { return _title; }
            set { _title = value; }
        }
        public string Description {
            get { return _description; }
            set { _description = value; }
        }

        public int TaskID {
            get { return _taskId; }
            set { _taskId = value; }
        }

        public bool IsCompleted { get; set; } = false;

        public DrawOptions Options { get; set; } = new DrawOptions();

        public abstract Task Clone();

        public override bool Equals(object obj)
        {
            Task otherTask = obj as Task;
            if (otherTask == null)
            {
                return false;
            }

            return this.TaskID == otherTask.TaskID;
        }
    }
}
