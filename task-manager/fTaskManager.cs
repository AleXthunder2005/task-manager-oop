﻿using System;
using System.Drawing;
using System.Windows.Forms;
using static task_manager.Settings;
using static task_manager.mTaskManager;
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

        private void pMainContent_MouseMove(object sender, MouseEventArgs e)
        {
            int y = e.Y;
            int newSelectedTaskIndex = y / (TaskHeightSetting + TASK_MARGIN);

            if (newSelectedTaskIndex >= 0 && newSelectedTaskIndex < mTaskManager.Tasks.Count)
            {
                if (SelectedTaskIndex != newSelectedTaskIndex)
                {
                    // Сбрасываем выделение только у старого элемента (если он был)
                    if (SelectedTaskIndex != RESETED_TASK_INDEX)
                    {
                        mTaskManager.Tasks[SelectedTaskIndex].Options.IsSelected = false;
                        InvalidateTaskRect(SelectedTaskIndex); 
                    }
                    mTaskManager.Tasks[newSelectedTaskIndex].Options.IsSelected = true;
                    SelectedTaskIndex = newSelectedTaskIndex;
                    InvalidateTaskRect(newSelectedTaskIndex); 
                }
            }
            else if (SelectedTaskIndex != RESETED_TASK_INDEX)
            {
                mTaskManager.Tasks[SelectedTaskIndex].Options.IsSelected = false;
                InvalidateTaskRect(SelectedTaskIndex); 
                SelectedTaskIndex = RESETED_TASK_INDEX;
            }
        }

        // Перерисовывает только область конкретной задачи
        private void InvalidateTaskRect(int taskIndex)
        {
            int yPos = taskIndex * (TaskHeightSetting + TASK_MARGIN) + TASK_MARGIN;
            pMainContent.Invalidate(new Rectangle(0, yPos, pMainContent.Width, TaskHeightSetting));
        }

        private void pMainContent_MouseLeave(object sender, EventArgs e)
        {
            if (SelectedTaskIndex != RESETED_TASK_INDEX)
            {
                mTaskManager.Tasks[SelectedTaskIndex].Options.IsSelected = false;
                InvalidateTaskRect(SelectedTaskIndex);
                SelectedTaskIndex = RESETED_TASK_INDEX;
            }
        }

        private void pMainContent_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int y = e.Y;
                int newSelectedTaskIndex = y / (TaskHeightSetting + TASK_MARGIN);

                if (newSelectedTaskIndex >= 0 && newSelectedTaskIndex < mTaskManager.Tasks.Count)
                {
                    ContextMenuStrip contextMenu = new ContextMenuStrip();
                    // Создаем пункт "Delete Task"
                    ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete Task");
                    deleteItem.Click += (s, args) => DeleteTask(newSelectedTaskIndex);

                    // Создаем пункт "Edit Task"
                    ToolStripMenuItem editItem = new ToolStripMenuItem("Edit Task");
                    editItem.Click += (s, args) => EditTask(newSelectedTaskIndex);

                    // Создаем пункт "Complete Task"
                    ToolStripMenuItem completeItem = new ToolStripMenuItem("Complete Task");
                    completeItem.Click += (s, args) => CompleteTask(newSelectedTaskIndex);

                    // Добавляем пункты в меню
                    contextMenu.Items.Add(deleteItem);
                    contextMenu.Items.Add(editItem);
                    contextMenu.Items.Add(completeItem);

                    contextMenu.Show(pMainContent, e.Location);
                }
            }
        }

        private void DeleteTask(int index)
        {
            if (index >= 0 && index < mTaskManager.Tasks.Count)
            {
                mTaskManager.Tasks.RemoveAt(index);
                UpdateAutoScrollMinSize();
                pMainContent.Invalidate();

            }
        }

        private void CompleteTask(int index)
        {
            if (index >= 0 && index < mTaskManager.Tasks.Count)
            {
                var task = mTaskManager.Tasks[index];

                if (task.GetType().Name == "ProgressTask")
                {
                    ProgressTask progressTask = (ProgressTask)task;
                    progressTask.CurrCount++;

                    if (progressTask.CurrCount == progressTask.GoalCount) 
                    {
                        mTaskManager.Tasks.RemoveAt(index);
                        UpdateAutoScrollMinSize();
                    }
                }
                else
                {
                    mTaskManager.Tasks.RemoveAt(index);
                    UpdateAutoScrollMinSize();
                }
                pMainContent.Invalidate();
            }
        }

        private void EditTask(int index)
        {
            if (index >= 0 && index < mTaskManager.Tasks.Count)
            {
                var taskToEdit = mTaskManager.Tasks[index];

                if (SelectedTaskIndex != RESETED_TASK_INDEX) {
                    Tasks[SelectedTaskIndex].Options.IsSelected = false;
                }

                fTaskCreator editForm = new fTaskCreator(TaskTypes, taskToEdit);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    Tasks[index] = editForm._createdTask;
                    pMainContent.Invalidate();
                }
            }
        }
    }
}
