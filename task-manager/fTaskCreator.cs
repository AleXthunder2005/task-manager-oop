using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static task_manager.PriorityTask;

namespace task_manager
{
    public partial class fTaskCreator: Form
    {
        private const string EMPTY_STRING = "";
        
        private string _selectedClassName = EMPTY_STRING;
        public Task _createdTask;
        public Type _createdTaskType;

        private Task _editingTask;
        public Task EditingTask { get { return _editingTask; } }

        //controllers
        public fTaskCreator(List<Type> taskTypes)
        {
            mTaskCreator.Initialize(taskTypes);
            InitializeComponent();
            InitializeUserComponent();
        }

        public fTaskCreator(List<Type> taskTypes, Task editingTask) : this(taskTypes)
        {
            _editingTask = editingTask;
            InitializeEditMode();
        }

        //model
        private void InitializeEditMode() {
            cbTaskType.Text = (string)_editingTask.GetType().GetField("taskTypeName").GetValue(null);
            tbTitle.Text = _editingTask.Title;
            tbDescription.Text = _editingTask.Description;

            string className = _editingTask.GetType().Name;

            TaskCreatorInitializer.FillTaskCreator(this, className, _editingTask);
        }

        private void InitializeUserComponent() 
        {
            foreach (var type in mTaskCreator.TaskTypes)
            {
                this.cbTaskType.Items.Add((string)type.GetField("taskTypeName").GetValue(null));
            }
        }
        private void CloseTaskCreator()
        {
            this.Clear();
            this.Close();
        }

        private string GetSelectedClassName() 
        {
            string className = "";
            foreach (var type in mTaskCreator.TaskTypes)
            {
                if (cbTaskType.Text == (string)type.GetField("taskTypeName").GetValue(null))
                {
                    className = type.Name;
                    return className;
                }
            }
            return null;
        }

        private Type GetSelectedClass()
        {
            string className = "";
            foreach (var type in mTaskCreator.TaskTypes)
            {
                if (cbTaskType.Text == (string)type.GetField("taskTypeName").GetValue(null))
                {
                    return type;
                }
            }
            return null;
        }



        private bool IsFormCorrect(out string message) 
        {
            if (cbTaskType.Text == EMPTY_STRING) { message = "Task was not selected!"; return false; } //ничего не выбрал - бан
            if (tbTitle.Text == EMPTY_STRING) { message = "Task name can't be empty!"; return false; } //пустое заглавие - бан


            if ((Controls.Find("dtpStartDate", true).FirstOrDefault() is DateTimePicker dtpStartDate) &&        //дедлайн раньше старта кринж
               (Controls.Find("dtpDeadlineDate", true).FirstOrDefault() is DateTimePicker dtpDeadlineDate))
             {
                if (dtpDeadlineDate.Value.CompareTo(dtpStartDate.Value) < 0) 
                {
                    message = "Deadline must be later, than start date!";
                    return false;
                }

                if (dtpStartDate.Value.Date.CompareTo(DateTime.Now.Date) < 0)     //Время старта раньше, чем сейчас
                {
                    message = "Start time must be later, than now!";
                    return false;
                }
            }
            
            if (Controls.Find("dtpSheduledTime", true).FirstOrDefault() is DateTimePicker dtpSheduledTime) //запланированное время меньше, чем сейчас
            {
                if (dtpSheduledTime.Value.Date.CompareTo(DateTime.Now.Date) < 0)
                {
                    message = "Sheduled time must be later, than now!";
                    return false;
                }

            }
            if (Controls.Find("cbInterval", true).FirstOrDefault() is ComboBox cbInterval)  //некорректное количество часов
            {
                if (!double.TryParse(cbInterval.Text, out double interval))
                {
                    message = "Enter correct interval hours count!";
                    return false;
                }
            }

            message = "Is correct!";
            return true;    
        }

        //view
        private void Clear()
        {
            tbTitle.Text = EMPTY_STRING;
            tbDescription.Text = EMPTY_STRING;
        }


        //controllers
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.CloseTaskCreator();
            DialogResult = DialogResult.Cancel;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string message;
            if (!IsFormCorrect(out message))
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; //бан
            }


            TaskOptions builder = new TaskOptions(this);
            builder.Build();
            _createdTask = (Task)Activator.CreateInstance(GetSelectedClass(), builder);

            this.DialogResult = DialogResult.OK;
            this.CloseTaskCreator();
        }

        private void cbTaskType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string oldSelectedClassName = _selectedClassName;

            _selectedClassName = GetSelectedClassName();
            TaskCreatorBuilder.Prepare(this, oldSelectedClassName);

            tbTitle.Text = $"New {cbTaskType.Text}";
            tbDescription.Text = $"I need to do ...";

            TaskCreatorBuilder.BuildTaskCreator(this, _selectedClassName);
        }
    }
}
