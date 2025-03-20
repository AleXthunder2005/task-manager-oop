using System;
using System.Collections.Generic;
using System.Drawing;
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

        public ReccuringSimpleTask(TaskBuilder builder) : base(builder)
        {
            Interval = builder.Interval;
        }

        //properties
        public double Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }
    }
}
