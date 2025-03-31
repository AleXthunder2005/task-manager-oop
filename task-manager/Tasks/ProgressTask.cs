﻿using System;
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

        public ProgressTask() : base() { }

        public ProgressTask(TaskBuilder builder) : base(builder)
        {
            GoalCount = builder.GoalCount;
            CurrCount = builder.CurrCount;
        }

        public override void SetOptions()
        {
            base.SetOptions();
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

        public override Task Clone()
        {
            return new ProgressTask
            {
                TaskID = this.TaskID,
                Title = this.Title,
                Description = this.Description,
                StartDate = this.StartDate,
                DeadlineDate = this.DeadlineDate,
                CurrCount = this.CurrCount,
                GoalCount = this.GoalCount,
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

            jsonBuilder.Append($",\n\t\"CurrCount\": \"{CurrCount}\"");
            jsonBuilder.Append($",\n\t\"GoalCount\": \"{GoalCount}\"");
            jsonBuilder.Append("\n}");
            return jsonBuilder.ToString();
        }

        public override bool IsReadingFromJsonObjectSuccessful(Task task, Dictionary<string, string> fields)
        {
            bool isBaseSuccessful = base.IsReadingFromJsonObjectSuccessful(task, fields);
            if (!isBaseSuccessful)
                return false;

            ProgressTask progressTask = task as ProgressTask;

            try
            {
                if (fields.ContainsKey("CurrCount"))
                {
                    progressTask.CurrCount = int.Parse(fields["CurrCount"]);
                }

                if (fields.ContainsKey("GoalCount"))
                {
                    progressTask.GoalCount = int.Parse(fields["GoalCount"]);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public override byte[] ToBinary()
        {
            var binaryBuilder = new StringBuilder(Encoding.UTF8.GetString(base.ToBinary()));
            binaryBuilder.Length--;

            binaryBuilder.Append($",CurrCount:{CurrCount}");
            binaryBuilder.Append($",GoalCount:{GoalCount}");

            binaryBuilder.Append(";");


            return Encoding.UTF8.GetBytes(binaryBuilder.ToString());
        }


        public override bool IsReadingFromBinaryObjectSuccessful(Task task, Dictionary<string, string> fields)
        {
            bool isBaseSuccessful = base.IsReadingFromBinaryObjectSuccessful(task, fields);
            if (!isBaseSuccessful)
                return false;

            ProgressTask progressTask = task as ProgressTask;

            try
            {
                if (fields.ContainsKey("CurrCount"))
                {
                    progressTask.CurrCount = int.Parse(fields["CurrCount"]);
                }

                if (fields.ContainsKey("GoalCount"))
                {
                    progressTask.GoalCount = int.Parse(fields["GoalCount"]);
                }
            }
            catch
            {
                return false;
            }

            return true;
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
