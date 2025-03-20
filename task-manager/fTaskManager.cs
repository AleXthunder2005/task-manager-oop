using System;
using System.Windows.Forms;
using static task_manager.Settings;

namespace task_manager
{
    public partial class fTaskManager: Form
    {
        public fTaskManager()
        {
            InitializeComponent();
            mTaskManager.Initialize();
            InitializeUserComponent();
            this.pMainContent.Paint += new PaintEventHandler(MainFormPaint);
        }

        //view
        private void MainFormPaint(object sender, PaintEventArgs e)
        {
            int y = TASK_MARGIN;
            int scrollOffset = pMainContent.AutoScrollPosition.Y;

            foreach (Task currTask in mTaskManager.Tasks)
            {
                currTask.Options.Y = y + scrollOffset;
                currTask.Options.X = currTask.Options.Margin;
                currTask.Options.Width = Settings.TaskWidthSetting;
                currTask.Options.Height = Settings.TaskHeightSetting;

                currTask.Draw(e.Graphics, currTask.Options);
                y += currTask.Options.Height + currTask.Options.Margin;
            }
        }

        //model
        private void ShowTaskCreator() {
            fTaskCreator taskCreator = new fTaskCreator(mTaskManager.TaskTypes);
            taskCreator.ShowDialog();

            if (taskCreator.DialogResult == DialogResult.OK) 
            {
                mTaskManager.Tasks.Add(taskCreator._createdTask);
            }
            UpdateAutoScrollMinSize();
            this.pMainContent.Invalidate();
        }
        private void CloseApplication() {
            this.Close();
        }

        private void InitializeUserComponent()
        {
            Settings.TaskWidthSetting = this.ClientSize.Width - this.pSideMenu.Width - 2 * TASK_MARGIN - SCROLLBAR_WIDTH;
        }
        private void UpdateAutoScrollMinSize()
        {
            int y = TASK_MARGIN;

            foreach (Task currTask in mTaskManager.Tasks)
            {
                y += currTask.Options.Height + currTask.Options.Margin;
            }
            pMainContent.AutoScrollMinSize = new System.Drawing.Size(0, y);
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

        private void fTaskManager_Resize(object sender, EventArgs e)
        {
            Settings.TaskWidthSetting = this.ClientSize.Width - this.pSideMenu.Width - 2 * TASK_MARGIN - SCROLLBAR_WIDTH;
            pMainContent.Invalidate();
        }
    }
}
