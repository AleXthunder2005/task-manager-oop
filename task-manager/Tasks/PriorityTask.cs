using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_manager
{
    public class PriorityTask : SimpleTask
    {
        //datatypes
        public enum t_priority
        {
            Low, 
            Medium,
            High
        };

        private t_priority _priority;
        public new static string taskTypeName = "Priority task";

        public PriorityTask(TaskBuilder builder) : base(builder)
        {
            Priority = builder.Priority;
            SetOptions();
        }

        protected override void SetOptions()
        {
            Color priorityColor;
            switch (Priority)
            {
                case t_priority.Low:
                    priorityColor = DrawOptions.clLOW_PRIORITY;
                    break;
                case t_priority.Medium:
                    priorityColor = DrawOptions.clMEDIUM_PRIORITY;
                    break;
                case t_priority.High:
                    priorityColor = DrawOptions.clHIGH_PRIORITY;
                    break;
                default:
                    priorityColor = Color.White;
                    break;
            }
            Options.BackgroundColor = priorityColor;
        }
        public override void Draw(Graphics g, DrawOptions options)
        {
            Brush textBrush = new SolidBrush(options.TextColor);
            Brush backgroundBrush = new SolidBrush(options.BackgroundColor);
            Pen borderPen = new Pen(options.BorderColor);



            Rectangle rect = new Rectangle(options.X, options.Y, 300, 100);
            g.FillRectangle(backgroundBrush, rect);
            g.DrawRectangle(borderPen, rect);

            base.Draw(g, options);
        }
        public override string ToString()
        {
            return $"{base.ToString()} with priority: {Priority}";
        }

        //properties
        public t_priority Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }


    }
}
