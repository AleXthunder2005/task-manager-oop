using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_manager
{
    class Reminder : Task
    {
        private DateTime _sheduledTime;
        private bool _isViewed;

        public new static string taskTypeName = "Reminder";

        public Reminder(TaskBuilder builder) : base(builder)
        {
            SheduledTime = builder.SheduledTime;
            IsViewed = builder.IsViewed;

            SetOptions();
        }

        protected override void SetOptions()
        {
            Options.BackgroundColor = DrawOptions.clREMINDER_BACKGROUNG;
        }

        public override void Draw(Graphics g, DrawOptions options)
        {
            Rectangle rect = new Rectangle(options.X, options.Y, options.Width, options.Height);
            Brush textBrush = new SolidBrush(options.TextColor);
            Pen borderPen = new Pen(options.BorderColor);
            Brush backgroundBrush = new SolidBrush(options.IsSelected ? DrawOptions.clSELECTED : options.BackgroundColor);

            g.FillRectangle(backgroundBrush, rect);
            g.DrawRectangle(borderPen, rect);

            g.DrawString($"{Title}", new Font("Arial", options.TitleFontSize, FontStyle.Bold), textBrush, options.X + options.Padding, options.Y + options.Padding);
            g.DrawString(Description, new Font("Arial", options.FontSize), textBrush, options.X + options.Padding, options.Y + options.Padding + 25);
            g.DrawString($"Reminder: {SheduledTime.ToString("D", new CultureInfo("en-US"))}", new Font("Arial", options.FontSize), textBrush, options.X + options.Padding, options.Y + options.Padding + 40);

        }
        public override string ToString()
        {
            return $"{Title}({Description}) - {SheduledTime.Date}";
        }

        //properties
        public DateTime SheduledTime
        {
            get { return _sheduledTime; }
            set { _sheduledTime = value; }
        }
 
        public bool IsViewed
        {
            get { return _isViewed; }
            set { _isViewed = value; }
        }
    }
}
