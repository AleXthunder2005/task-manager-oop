﻿using System;
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

        public Reminder():base() { }

        public Reminder(TaskBuilder builder) : base(builder)
        {
            SheduledTime = builder.SheduledTime;
            IsViewed = builder.IsViewed;

            SetOptions();
        }

        public override void SetOptions()
        {
            Options.BackgroundColor = DrawOptions.clREMINDER_BACKGROUNG;
        }

        public override void Draw(Graphics g, DrawOptions options)
        {
            Rectangle rect = new Rectangle(options.X, options.Y, options.Width, options.Height);
            Brush textBrush = new SolidBrush(options.TextColor);
            Pen borderPen = new Pen(options.BorderColor);
            Brush backgroundBrush = new SolidBrush(options.IsSelected ? DrawOptions.clSELECTED : IsCompleted ? DrawOptions.clCOMPLETED : options.BackgroundColor);

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

        public override Task Clone()
        {
            return new Reminder
            {
                TaskID = this.TaskID,
                Title = this.Title,
                Description = this.Description,
                SheduledTime = this.SheduledTime,
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

            jsonBuilder.Append($",\n\t\"SheduledTime\":\"{SheduledTime: yyyy-MM-dd}\"");
            jsonBuilder.Append("\n}");
            return jsonBuilder.ToString();
        }

        public void ReadPropertyFromJSON(Reminder task, Dictionary<string, string> jsonObject)
        {
            base.ReadPropertyFromJSON(task, jsonObject);
            
            if (jsonObject.ContainsKey("SheduledTime"))
            {
                task.SheduledTime = DateTime.ParseExact(
                    jsonObject["SheduledTime"],
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture
                );
            }
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
