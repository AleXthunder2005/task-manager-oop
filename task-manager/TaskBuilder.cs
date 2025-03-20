using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static task_manager.PriorityTask;

namespace task_manager
{
    public class TaskBuilder
    {
        private fTaskCreator _taskCreator;

        //task
        private string _title = "New task";
        private string _description = "-";

        // simple_task
        private DateTime _startDate = DateTime.Now.Date;
        private DateTime _deadlineDate = DateTime.Now.Date;
        private bool _isCompleted = false;

        // reminder
        private DateTime _sheduledTime = DateTime.Now.Date;
        private bool _isViewed = false;

        // reccuring_simple_task
        private double _interval = 1; // в часах

        // progress task
        private int _goalCount = 100;
        private int _currCount = 0;

        // priority_task
        private t_priority _priority = t_priority.Low;

        // properties
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime DeadlineDate
        {
            get { return _deadlineDate; }
            set { _deadlineDate = value; }
        }

        public bool IsCompleted
        {
            get { return _isCompleted; }
            set { _isCompleted = value; }
        }

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

        public double Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }

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

        public t_priority Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }

        public TaskBuilder() { }
        public TaskBuilder(fTaskCreator taskCreator) 
        {
            _taskCreator = taskCreator;
        }
        public TaskBuilder Build()
        {
            // Проверяем, существует ли форма _taskCreator
            if (_taskCreator != null)
            {
                if (_taskCreator.Controls.Find("tbTitle", true).FirstOrDefault() is TextBox tbTitle) { _title = tbTitle.Text; }
                if (_taskCreator.Controls.Find("tbDescription", true).FirstOrDefault() is TextBox tbDescription) { _description = tbDescription.Text; }
                if (_taskCreator.Controls.Find("dtpStartDate", true).FirstOrDefault() is DateTimePicker dtpStartDate)   { _startDate = dtpStartDate.Value.Date; }
                if (_taskCreator.Controls.Find("dtpDeadlineDate", true).FirstOrDefault() is DateTimePicker dtpDeadlineDate) { _deadlineDate = dtpDeadlineDate.Value.Date; }
                if (_taskCreator.Controls.Find("dtpSheduledTime", true).FirstOrDefault() is DateTimePicker dtpSheduledTime) { _sheduledTime = dtpSheduledTime.Value.Date; }
                if (_taskCreator.Controls.Find("cbInterval", true).FirstOrDefault() is ComboBox cbInterval)
                {
                    if (double.TryParse(cbInterval.Text, out double interval))
                    {
                        _interval = interval;
                    }
                }
                if (_taskCreator.Controls.Find("udGoalCount", true).FirstOrDefault() is NumericUpDown udGoalCount)
                {
                    if (int.TryParse(udGoalCount.Text, out int goalCount))
                    {
                        _goalCount = goalCount;
                    }
                }

                if (_taskCreator.Controls.Find("cbPriority", true).FirstOrDefault() is ComboBox cbPriority)
                {
                    if (cbPriority.SelectedItem != null && Enum.TryParse(cbPriority.SelectedItem.ToString(), out t_priority priority))
                    {
                        _priority = priority;
                    }
                }
            }

            return this;
        }
    }
}
