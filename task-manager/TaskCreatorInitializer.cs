using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System;

namespace task_manager
{
    public static class TaskCreatorInitializer
    {
        public static void FillTaskCreator(fTaskCreator taskCreator, string className, Task editingTask)
        {
            string methodName = $"Fill{className}Creator";
            Type type = typeof(TaskCreatorInitializer);
            MethodInfo method = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static);

            if (method != null)
            {
                method.Invoke(null, new object[] { taskCreator, editingTask });
                taskCreator.Invalidate();
            }
        }

        private static void FillSimpleTaskCreator(fTaskCreator taskCreator, Task editingTask)
        {
            var simpleTask = editingTask as SimpleTask;
            if (simpleTask == null) return;

            // Заполняем DateTimePicker'ы
            var dtpStartDate = taskCreator.Controls.Find("dtpStartDate", true).FirstOrDefault() as DateTimePicker;
            var dtpDeadlineDate = taskCreator.Controls.Find("dtpDeadlineDate", true).FirstOrDefault() as DateTimePicker;

            if (dtpStartDate != null) dtpStartDate.Value = simpleTask.StartDate;
            if (dtpDeadlineDate != null) dtpDeadlineDate.Value = simpleTask.DeadlineDate;
        }

        private static void FillReminderCreator(fTaskCreator taskCreator, Task editingTask)
        {
            var reminder = editingTask as Reminder;
            if (reminder == null) return;

            var dtpSheduledTime = taskCreator.Controls.Find("dtpSheduledTime", true).FirstOrDefault() as DateTimePicker;
            if (dtpSheduledTime != null) dtpSheduledTime.Value = reminder.SheduledTime;
        }

        private static void FillReccuringSimpleTaskCreator(fTaskCreator taskCreator, Task editingTask)
        {
            var recurringTask = editingTask as ReccuringSimpleTask;
            if (recurringTask == null) return;

            // Заполняем базовые поля SimpleTask
            FillSimpleTaskCreator(taskCreator, editingTask);

            // Заполняем ComboBox интервала
            var cbInterval = taskCreator.Controls.Find("cbInterval", true).FirstOrDefault() as ComboBox;
            if (cbInterval != null)
            {
                var intervalString = recurringTask.Interval.ToString();
                cbInterval.SelectedItem = intervalString;
            }
        }

        private static void FillPriorityTaskCreator(fTaskCreator taskCreator, Task editingTask)
        {
            var priorityTask = editingTask as PriorityTask;
            if (priorityTask == null) return;

            // Заполняем базовые поля SimpleTask
            FillSimpleTaskCreator(taskCreator, editingTask);

            // Заполняем ComboBox приоритета
            var cbPriority = taskCreator.Controls.Find("cbPriority", true).FirstOrDefault() as ComboBox;
            if (cbPriority != null)
            {
                cbPriority.SelectedItem = priorityTask.Priority.ToString();
            }
        }

        private static void FillProgressTaskCreator(fTaskCreator taskCreator, Task editingTask)
        {
            var progressTask = editingTask as ProgressTask;
            if (progressTask == null) return;

            // Заполняем базовые поля SimpleTask
            FillSimpleTaskCreator(taskCreator, editingTask);

            // Заполняем NumericUpDown количества целей
            var udGoalCount = taskCreator.Controls.Find("udGoalCount", true).FirstOrDefault() as NumericUpDown;
            if (udGoalCount != null)
            {
                udGoalCount.Value = progressTask.GoalCount;
            }
        }
    }
}