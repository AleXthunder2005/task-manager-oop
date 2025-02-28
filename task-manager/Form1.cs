using System;
using System.Windows.Forms;

namespace task_manager
{
    public partial class wTaskManager: Form
    {
        public wTaskManager()
        {
            InitializeComponent();
            TaskManagerModel.LoadTaskTypes();

            this.pMainContent.Paint += new PaintEventHandler(MainFormPaint);
        }
        //controllers
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            this.ShowTaskCreator();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.ExitApplication();
        }



        //view
        private void MainFormPaint(object sender, PaintEventArgs e)
        {
            //int y = 10;

            //foreach (Task currTask in TaskManagerModel.Tasks) 
            //{
            //    currTask.Draw(e.Graphics, 20, y);
            //    y += 110;
            //}
        }


        //model
        private void ShowTaskCreator() {
            wTaskCreator taskCreator = new wTaskCreator();
            taskCreator.Show();
        }
        private void ExitApplication() {
            this.Close();
        }
    }
}
