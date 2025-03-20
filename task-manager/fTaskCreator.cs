using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace task_manager
{
    public partial class fTaskCreator: Form
    {
        private const string EMPTY_STRING = "";
        
        private string _selectedClassName = EMPTY_STRING;
        public Task _createdTask;
        public Type _createdTaskType;

        //controllers
        public fTaskCreator(List<Type> taskTypes)
        {
            mTaskCreator.Initialize(taskTypes);
            InitializeComponent();
            InitializeUserComponent();
        }

        //model
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
            if (_selectedClassName == null) return;
            TaskBuilder builder = new TaskBuilder(this);
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
            TaskCreatorBuilder.BuildTaskCreator(this, _selectedClassName);
        }
    }
}
