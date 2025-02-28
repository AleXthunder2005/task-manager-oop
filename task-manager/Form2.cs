using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_manager
{
    public partial class wTaskCreator: Form
    {
        private const string EMPTY_STRING = "";


        //controllers
        public wTaskCreator()
        {
            InitializeComponent();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.CloseTaskCreator();
        }


        //view
        private void Clear()
        {
            tbTaskName.Text = EMPTY_STRING;
            tbTaskDescription.Text = EMPTY_STRING;
        }

        private void CloseTaskCreator() {
            this.Clear();
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //TaskCreatorModel.CreateTask();
        }
    }
}
