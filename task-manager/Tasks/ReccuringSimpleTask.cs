﻿using System;
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

        public override void SetOptions()
        {
            base.SetOptions();
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
            jsonBuilder.Append(baseJson, 1, baseJson.Length - 1); //обрезали первый {
            jsonBuilder.Length -= 2; //Обрезали последний '\n}'

            jsonBuilder.Append($",\n\t\"Interval\": \"{Interval}\"");
            jsonBuilder.Append("\n}");
            return jsonBuilder.ToString();
        }

        public override bool IsReadingFromJsonObjectSuccessful(Task task, Dictionary<string, string> fields)
        {
            bool isBaseSuccessful = base.IsReadingFromJsonObjectSuccessful(task, fields);
            if (!isBaseSuccessful)
                return false;

            ReccuringSimpleTask reccuringSimpleTask = task as ReccuringSimpleTask;

            try
            {
                if (fields.ContainsKey("Interval"))
                {
                    reccuringSimpleTask.Interval = int.Parse(fields["Interval"]);
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

            binaryBuilder.Append($",Interval:{Interval}");

            binaryBuilder.Append(";");


            return Encoding.UTF8.GetBytes(binaryBuilder.ToString());
        }

        public override bool IsReadingFromBinaryObjectSuccessful(Task task, Dictionary<string, string> fields)
        {
            bool isBaseSuccessful = base.IsReadingFromBinaryObjectSuccessful(task, fields);
            if (!isBaseSuccessful)
                return false;

            ReccuringSimpleTask reccuringSimpleTask = task as ReccuringSimpleTask;

            try
            {
                if (fields.ContainsKey("Interval"))
                {
                    reccuringSimpleTask.Interval = int.Parse(fields["Interval"]);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        //properties
        public double Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }
    }
}
