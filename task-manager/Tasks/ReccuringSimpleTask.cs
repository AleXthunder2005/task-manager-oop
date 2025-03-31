using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_manager
{
    class ReccuringSimpleTask : SimpleTask
    {
        private double _interval; // в часах
        
        public new static string taskTypeName = "Reccuring simple task";

        public override void Draw(Graphics g, DrawOptions options)
        {
            base.Draw(g, options);
        }

        public override string ToString()
        {
            return $"{base.ToString()} with interval {Interval}";
        }

        public ReccuringSimpleTask() : base() { }

        public ReccuringSimpleTask(TaskBuilder builder) : base(builder)
        {
            Interval = builder.Interval;
        }

        public override Task Clone()
        {
            return new ReccuringSimpleTask
            {
                TaskID = this.TaskID,
                Title = this.Title,
                Description = this.Description,
                StartDate = this.StartDate,
                DeadlineDate = this.DeadlineDate,
                Interval = this.Interval,
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
            baseJson = baseJson.Trim('{', '}');

            jsonBuilder.Append(baseJson);

            jsonBuilder.Append($",\"Interval\": \"{Interval}\"");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

        public void ReadPropertyFromJSON(ReccuringSimpleTask task, Dictionary<string, string> jsonObject)
        {
            base.ReadPropertyFromJSON(task, jsonObject);

            if (jsonObject.ContainsKey("Interval"))
            {
                task.Interval = int.Parse(jsonObject["Interval"]);
            }
        }

        //properties
        public double Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }
    }
}
