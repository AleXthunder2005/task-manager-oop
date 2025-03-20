using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_manager
{
    class ProgressTask : SimpleTask
    {
        private int _goalCount;
        private int _currCount;

        public new static string taskTypeName = "Progress task";

        public ProgressTask(TaskBuilder builder) : base(builder)
        {
            GoalCount = builder.GoalCount;
            CurrCount = builder.CurrCount;
        }

        public override void Draw(Graphics g, DrawOptions options)
        {
            Brush textBrush = new SolidBrush(options.TextColor);
            Pen borderPen = new Pen(options.BorderColor);

            base.Draw(g, options);
           

            int x = options.X + options.Padding + 2;
            int y = options.Y + Options.Height - 2 * options.Padding - 5;
            int width = options.Width - 2 * options.Padding - 50;
            int height = options.ProgressBarHeight;

            Rectangle progressBar = new Rectangle(x, y, width, height);
            Brush progressBarBackgroundBrush = new SolidBrush(options.ProgressBarBackgroundColor);
            g.FillRectangle(progressBarBackgroundBrush, progressBar);

            if (CurrCount > 0 && GoalCount != 0)
            {
                int fillWidth = (int)Math.Round((double)CurrCount / GoalCount * width);
                Rectangle progressBarFill = new Rectangle(x, y, fillWidth, height);
                Brush progressBarFillBrush = new SolidBrush(options.ProgressBarFillColor);
                g.FillRectangle(progressBarFillBrush, progressBarFill);
            }

            g.DrawString($"{CurrCount} / {GoalCount}", new Font("Arial", options.FontSize), textBrush, x + width + options.Padding, y);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, current result: {CurrCount}/{GoalCount}";
        }

        //properties
        public int GoalCount
        {
            get { return _goalCount; }
            set { _goalCount = value; }
        }

        public int CurrCount
        {
            get { return _currCount; }
            set { _currCount = value; }
        }
    }
}
