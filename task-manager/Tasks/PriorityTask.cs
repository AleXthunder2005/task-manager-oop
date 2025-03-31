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

        public PriorityTask() { }

        public PriorityTask(TaskBuilder builder) : base(builder)
        {
            Priority = builder.Priority;
            SetOptions();
        }

        public override void SetOptions()
        {
            base.SetOptions();
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
            Brush backgroundBrush = new SolidBrush(IsCompleted ? DrawOptions.clCOMPLETED : options.BackgroundColor);
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

        public override Task Clone()
        {
            return new PriorityTask
            {
                TaskID = this.TaskID,
                Title = this.Title,
                Description = this.Description,
                StartDate = this.StartDate,
                DeadlineDate = this.DeadlineDate,
                Priority = this.Priority,
                IsCompleted = this.IsCompleted,
                Options = new DrawOptions
                {
                    IsSelected = this.Options.IsSelected,
                    X = this.Options.X,
                    Y = this.Options.Y,
                    Width = this.Options.Width,
                    Height = this.Options.Height,
                    Margin = this.Options.Margin,
                    BackgroundColor = this.Options.BackgroundColor,
                    TextColor = this.Options.TextColor,
                    FontSize = this.Options.FontSize,
                }
            };
        }

        public override string ToJSON()
        {
            var jsonBuilder = new StringBuilder("{");

            string baseJson = base.ToJSON();
            jsonBuilder.Append(baseJson, 1, baseJson.Length - 1); //обрезали первый {
            jsonBuilder.Length -= 2; //Обрезали последний '\n}'

            jsonBuilder.Append($",\n\t\"Priority\": \"{Priority}\"");
            jsonBuilder.Append("\n}");
            return jsonBuilder.ToString();
        }

        public void ReadPropertyFromJSON(PriorityTask task, Dictionary<string, string> jsonObject)
        {
            base.ReadPropertyFromJSON(task, jsonObject);

            if (Enum.TryParse(jsonObject["Priority"], out t_priority priority))
            {
                task.Priority = priority;
            }
        }

        //properties
        public t_priority Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }


    }
}
