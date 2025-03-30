using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_manager
{
    public class SimpleTask : Task
    {
        private DateTime _startDate;
        private DateTime _deadlineDate;

        public new static string taskTypeName = "Simple task";
        public SimpleTask() : base() { }

        public SimpleTask(TaskBuilder builder) : base(builder)
        {
            int count = _idCounter;

            StartDate = builder.StartDate;
            DeadlineDate = builder.DeadlineDate;
            IsCompleted = builder.IsCompleted;

            

            SetOptions();
        }
        protected override void SetOptions()
        {
            
        }

        public override void Draw(Graphics g, DrawOptions options)
        {
            Rectangle rect = new Rectangle(options.X, options.Y, options.Width, options.Height);
            Brush textBrush = new SolidBrush(options.TextColor);
            Pen borderPen = new Pen(options.BorderColor);
            Brush backgroundBrush = new SolidBrush(options.IsSelected ? DrawOptions.clSELECTED: IsCompleted ? DrawOptions.clCOMPLETED : options.BackgroundColor);



            g.FillRectangle(backgroundBrush, rect);
            g.DrawRectangle(borderPen, rect);

            g.DrawString($"{Title}", new Font("Arial", options.TitleFontSize, FontStyle.Bold), textBrush, options.X + options.Padding, options.Y + options.Padding);
            g.DrawString(Description, new Font("Arial", options.FontSize), textBrush, options.X + options.Padding, options.Y + options.Padding + 25);
            g.DrawString($"Start: {StartDate.ToString("D", new CultureInfo("en-US"))}", new Font("Arial", options.FontSize), textBrush, options.X + options.Padding    , options.Y + options.Padding + 40);
            g.DrawString($"Deadline: {DeadlineDate.ToString("D", new CultureInfo("en-US"))}", new Font("Arial", options.FontSize), textBrush, options.X + options.Padding, options.Y + options.Padding + 55);
        }

        public override string ToString() 
        {
            return $"{Title}({Description}) {StartDate.Date} - {DeadlineDate}";
        }

        public override Task Clone()
        {
            return new SimpleTask
            {
                TaskID = this.TaskID,
                Title = this.Title,
                Description = this.Description,
                StartDate = this.StartDate,
                DeadlineDate = this.DeadlineDate,
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

        //properties
        public DateTime StartDate {
            get { return _startDate; }
            set { _startDate = value; }
        }
        public DateTime DeadlineDate
        {
            get { return _deadlineDate; }
            set { _deadlineDate = value; }
        }
    }
}
