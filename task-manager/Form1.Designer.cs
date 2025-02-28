namespace task_manager
{
    partial class wTaskManager
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pSideMenu = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCreateProject = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.pTop = new System.Windows.Forms.Panel();
            this.lTitile = new System.Windows.Forms.Label();
            this.pMainContent = new System.Windows.Forms.Panel();
            this.pSideMenu.SuspendLayout();
            this.pTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pSideMenu
            // 
            this.pSideMenu.BackColor = System.Drawing.Color.DarkCyan;
            this.pSideMenu.Controls.Add(this.btnExit);
            this.pSideMenu.Controls.Add(this.btnCreateProject);
            this.pSideMenu.Controls.Add(this.btnAddTask);
            this.pSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pSideMenu.Location = new System.Drawing.Point(0, 0);
            this.pSideMenu.Name = "pSideMenu";
            this.pSideMenu.Size = new System.Drawing.Size(237, 769);
            this.pSideMenu.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(21, 717);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(199, 40);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCreateProject
            // 
            this.btnCreateProject.Location = new System.Drawing.Point(21, 105);
            this.btnCreateProject.Name = "btnCreateProject";
            this.btnCreateProject.Size = new System.Drawing.Size(199, 40);
            this.btnCreateProject.TabIndex = 2;
            this.btnCreateProject.Text = "Create project";
            this.btnCreateProject.UseVisualStyleBackColor = true;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(21, 59);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(199, 40);
            this.btnAddTask.TabIndex = 1;
            this.btnAddTask.Text = "Add task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // pTop
            // 
            this.pTop.BackColor = System.Drawing.Color.DarkSalmon;
            this.pTop.Controls.Add(this.lTitile);
            this.pTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTop.Location = new System.Drawing.Point(237, 0);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(1006, 59);
            this.pTop.TabIndex = 1;
            // 
            // lTitile
            // 
            this.lTitile.AutoSize = true;
            this.lTitile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lTitile.Font = new System.Drawing.Font("MS PGothic", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lTitile.Location = new System.Drawing.Point(0, 0);
            this.lTitile.Name = "lTitile";
            this.lTitile.Size = new System.Drawing.Size(166, 42);
            this.lTitile.TabIndex = 0;
            this.lTitile.Text = "Task list";
            this.lTitile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pMainContent
            // 
            this.pMainContent.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMainContent.Location = new System.Drawing.Point(237, 59);
            this.pMainContent.Name = "pMainContent";
            this.pMainContent.Size = new System.Drawing.Size(1006, 710);
            this.pMainContent.TabIndex = 2;
            // 
            // wTaskManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 769);
            this.Controls.Add(this.pMainContent);
            this.Controls.Add(this.pTop);
            this.Controls.Add(this.pSideMenu);
            this.Name = "wTaskManager";
            this.Text = "Task Manager";
            this.pSideMenu.ResumeLayout(false);
            this.pTop.ResumeLayout(false);
            this.pTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pSideMenu;
        private System.Windows.Forms.Panel pTop;
        private System.Windows.Forms.Label lTitile;
        private System.Windows.Forms.Panel pMainContent;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCreateProject;
    }
}

