using System;
using System.Windows.Forms;

namespace task_manager
{
    public partial class wTaskManager: Form
    {
        public wTaskManager()
        {
            InitializeComponent();
            mTaskManager.Initialize();

            this.pMainContent.Paint += new PaintEventHandler(MainFormPaint);
        }
        //controllers
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            this.ShowTaskCreator();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.CloseApplication();
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
            wTaskCreator taskCreator = new wTaskCreator(mTaskManager.TaskTypes);
            taskCreator.Show();
        }
        private void CloseApplication() {
            this.Close();
        }
    }
}
