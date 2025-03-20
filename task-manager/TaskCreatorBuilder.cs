using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace task_manager
{
    static class TaskCreatorBuilder
    {
        public static void BuildTaskCreator(fTaskCreator taskCreator, string className)
        {
            string methodName = $"Build{className}Creator";
            Type type = typeof(TaskCreatorBuilder);
            MethodInfo method = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static);

            if (method != null)
            {
                // Вызываем метод, передавая taskCreator в качестве параметра
                method.Invoke(null, new object[] { taskCreator });
                taskCreator.Invalidate();
            }
        }

        public static void Prepare(fTaskCreator taskCreator, string className)
        {
            string methodName = $"Dispose{className}Creator";
            Type type = typeof(TaskCreatorBuilder);
            MethodInfo method = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static);

            if (method != null)
            {
                // Вызываем метод, передавая taskCreator в качестве параметра
                method.Invoke(null, new object[] { taskCreator });
            }
        }

        private static void BuildSimpleTaskCreator(fTaskCreator taskCreator)
        {
            // Создаем и настраиваем DateTimePicker для начальной даты
            DateTimePicker dtpStartDate = new DateTimePicker();
            dtpStartDate.Location = new System.Drawing.Point(189, 252);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new System.Drawing.Size(362, 22);
            dtpStartDate.TabIndex = 10;
            taskCreator.Controls.Add(dtpStartDate);

            // Создаем и настраиваем DateTimePicker для даты дедлайна
            DateTimePicker dtpDeadlineDate = new DateTimePicker();
            dtpDeadlineDate.Location = new System.Drawing.Point(189, 280);
            dtpDeadlineDate.Name = "dtpDeadlineDate";
            dtpDeadlineDate.Size = new System.Drawing.Size(362, 22);
            dtpDeadlineDate.TabIndex = 11;
            taskCreator.Controls.Add(dtpDeadlineDate);

            // Создаем и настраиваем Label для начальной даты
            Label lStartDate = new Label();
            lStartDate.AutoSize = true;
            lStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            lStartDate.Location = new System.Drawing.Point(52, 254);
            lStartDate.Name = "lStartDate";
            lStartDate.Size = new System.Drawing.Size(92, 20);
            lStartDate.TabIndex = 12;
            lStartDate.Text = "Start date";
            taskCreator.Controls.Add(lStartDate);

            // Создаем и настраиваем Label для даты дедлайна
            Label lDeadlineDate = new Label();
            lDeadlineDate.AutoSize = true;
            lDeadlineDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            lDeadlineDate.Location = new System.Drawing.Point(52, 282);
            lDeadlineDate.Name = "lDeadlineDate";
            lDeadlineDate.Size = new System.Drawing.Size(115, 20);
            lDeadlineDate.TabIndex = 13;
            lDeadlineDate.Text = "Deadline date";
            taskCreator.Controls.Add(lDeadlineDate);
        }

        private static void DisposeSimpleTaskCreator(fTaskCreator taskCreator)
        {
            // Удаляем компоненты, связанные с SimpleTaskCreator
            RemoveControlByName(taskCreator, "dtpStartDate");
            RemoveControlByName(taskCreator, "dtpDeadlineDate");
            RemoveControlByName(taskCreator, "lStartDate");
            RemoveControlByName(taskCreator, "lDeadlineDate");
        }

        private static void BuildReminderCreator(fTaskCreator taskCreator)
        {
            // Создаем и настраиваем DateTimePicker для запланированного времени
            DateTimePicker dtpSheduledTime = new DateTimePicker();
            dtpSheduledTime.Location = new System.Drawing.Point(189, 252);
            dtpSheduledTime.Name = "dtpSheduledTime";
            dtpSheduledTime.Size = new System.Drawing.Size(362, 22);
            dtpSheduledTime.TabIndex = 10;
            taskCreator.Controls.Add(dtpSheduledTime); // Добавляем на форму

            // Создаем и настраиваем Label для запланированного времени
            Label lStartDate = new Label();
            lStartDate.AutoSize = true;
            lStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            lStartDate.Location = new System.Drawing.Point(52, 254);
            lStartDate.Name = "lStartDate";
            lStartDate.Size = new System.Drawing.Size(128, 20);
            lStartDate.TabIndex = 12;
            lStartDate.Text = "Scheduled time";
            taskCreator.Controls.Add(lStartDate); // Добавляем на форму
        }

        private static void DisposeReminderCreator(fTaskCreator taskCreator)
        {
            // Удаляем компоненты, связанные с RemainderCreator
            RemoveControlByName(taskCreator, "dtpSheduledTime");
            RemoveControlByName(taskCreator, "lStartDate");
        }

        private static void BuildReccuringSimpleTaskCreator(fTaskCreator taskCreator)
        {
            BuildSimpleTaskCreator(taskCreator);

            System.Windows.Forms.ComboBox cbInterval = new System.Windows.Forms.ComboBox();
            cbInterval.FormattingEnabled = true;
            cbInterval.Items.AddRange(new object[] {
                "0.25",
                "0.5",
                "0.75",
                "1",
                "1.5",
                "2",
                "2.5",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "11",
                "12",
                "24"
            });
            cbInterval.Location = new System.Drawing.Point(189, 340);
            cbInterval.Name = "cbInterval";
            cbInterval.Size = new System.Drawing.Size(362, 24);
            cbInterval.TabIndex = 13;
            taskCreator.Controls.Add(cbInterval); // Добавляем на форму

            // Создаем и настраиваем Label для текста "Interval"
            Label lInterval = new Label();
            lInterval.AutoSize = true;
            lInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            lInterval.Location = new System.Drawing.Point(52, 340);
            lInterval.Name = "lInterval";
            lInterval.Size = new System.Drawing.Size(71, 20);
            lInterval.TabIndex = 14;
            lInterval.Text = "Interval";
            taskCreator.Controls.Add(lInterval); // Добавляем на форму
        }

        private static void DisposeReccuringSimpleTaskCreator(fTaskCreator taskCreator)
        {
            // Удаляем компоненты, связанные с ReccuringSimpleTaskCreator
            DisposeSimpleTaskCreator(taskCreator); // Удаляем базовые компоненты
            RemoveControlByName(taskCreator, "cbInterval");
            RemoveControlByName(taskCreator, "lInterval");
        }

        private static void BuildPriorityTaskCreator(fTaskCreator taskCreator)
        {
            // Вызываем метод BuildSimpleTaskCreator для создания базовых элементов
            BuildSimpleTaskCreator(taskCreator);

            // Создаем и настраиваем ComboBox для приоритета
            System.Windows.Forms.ComboBox cbPriority = new System.Windows.Forms.ComboBox();
            cbPriority.FormattingEnabled = true;
            cbPriority.Location = new System.Drawing.Point(189, 340);
            cbPriority.Name = "cbPriority";
            cbPriority.Size = new System.Drawing.Size(362, 24);
            cbPriority.TabIndex = 13;
            cbPriority.Items.AddRange(new object[] {
                "Low",
                "Medium",
                "High"
            });
            cbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPriority.SelectedIndex = 0;
            taskCreator.Controls.Add(cbPriority); // Добавляем на форму

            // Создаем и настраиваем Label для текста "Priority"
            Label lPriority = new Label();
            lPriority.AutoSize = true;
            lPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            lPriority.Location = new System.Drawing.Point(52, 340);
            lPriority.Name = "lPriority";
            lPriority.Size = new System.Drawing.Size(70, 20);
            lPriority.TabIndex = 14;
            lPriority.Text = "Priority";
            taskCreator.Controls.Add(lPriority); // Добавляем на форму
        }

        private static void DisposePriorityTaskCreator(fTaskCreator taskCreator)
        {
            // Удаляем компоненты, связанные с PriorityTaskCreator
            DisposeSimpleTaskCreator(taskCreator); // Удаляем базовые компоненты
            RemoveControlByName(taskCreator, "cbPriority");
            RemoveControlByName(taskCreator, "lPriority");
        }

        private static void BuildProgressTaskCreator(fTaskCreator taskCreator)
        {
            // Вызываем метод BuildSimpleTaskCreator для создания базовых элементов
            BuildSimpleTaskCreator(taskCreator);

            Label lGoalCount = new Label();
            lGoalCount.AutoSize = true;
            lGoalCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            lGoalCount.Location = new System.Drawing.Point(52, 340);
            lGoalCount.Name = "lGoalCount";
            lGoalCount.Size = new System.Drawing.Size(100, 20);
            lGoalCount.TabIndex = 14;
            lGoalCount.Text = "Goal count";
            taskCreator.Controls.Add(lGoalCount);

            // Создаем и настраиваем NumericUpDown для ввода количества целей
            NumericUpDown udGoalCount = new NumericUpDown();
            udGoalCount.Location = new System.Drawing.Point(189, 340);
            udGoalCount.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            udGoalCount.Minimum = 1;
            udGoalCount.Name = "udGoalCount";
            udGoalCount.Size = new System.Drawing.Size(362, 22);
            udGoalCount.TabIndex = 15;
            taskCreator.Controls.Add(udGoalCount);
        }

        private static void DisposeProgressTaskCreator(fTaskCreator taskCreator)
        {
            // Удаляем компоненты, связанные с ProgressTaskCreator
            DisposeSimpleTaskCreator(taskCreator); // Удаляем базовые компоненты
            RemoveControlByName(taskCreator, "lGoalCount");
            RemoveControlByName(taskCreator, "udGoalCount");
        }

        // Вспомогательный метод для удаления компонента по имени
        private static void RemoveControlByName(fTaskCreator taskCreator, string controlName)
        {
            var control = taskCreator.Controls.Find(controlName, true).FirstOrDefault();
            if (control != null)
            {
                taskCreator.Controls.Remove(control);
                control.Dispose(); // Освобождаем ресурсы
            }
        }
    }
}