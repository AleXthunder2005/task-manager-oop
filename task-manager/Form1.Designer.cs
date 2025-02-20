namespace task_manager
{
    partial class MainForm
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
            this.sideMenuPanel = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_AddRecurringTask = new System.Windows.Forms.Button();
            this.btn_PriorityTask = new System.Windows.Forms.Button();
            this.btn_ProgressTask = new System.Windows.Forms.Button();
            this.sideMenuPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sideMenuPanel
            // 
            this.sideMenuPanel.BackColor = System.Drawing.Color.DarkCyan;
            this.sideMenuPanel.Controls.Add(this.btn_ProgressTask);
            this.sideMenuPanel.Controls.Add(this.btn_PriorityTask);
            this.sideMenuPanel.Controls.Add(this.btn_AddRecurringTask);
            this.sideMenuPanel.Controls.Add(this.button1);
            this.sideMenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.sideMenuPanel.Name = "sideMenuPanel";
            this.sideMenuPanel.Size = new System.Drawing.Size(237, 769);
            this.sideMenuPanel.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.DarkSalmon;
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(237, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1006, 59);
            this.topPanel.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Font = new System.Drawing.Font("Monotype Corsiva", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(416, 51);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Запланированные задачи";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Location = new System.Drawing.Point(237, 59);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Size = new System.Drawing.Size(1006, 710);
            this.mainContentPanel.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Добавить простую задачу";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_AddRecurringTask
            // 
            this.btn_AddRecurringTask.Location = new System.Drawing.Point(21, 105);
            this.btn_AddRecurringTask.Name = "btn_AddRecurringTask";
            this.btn_AddRecurringTask.Size = new System.Drawing.Size(199, 52);
            this.btn_AddRecurringTask.TabIndex = 2;
            this.btn_AddRecurringTask.Text = "Добавить регулярную задачу";
            this.btn_AddRecurringTask.UseVisualStyleBackColor = true;
            // 
            // btn_PriorityTask
            // 
            this.btn_PriorityTask.Location = new System.Drawing.Point(21, 163);
            this.btn_PriorityTask.Name = "btn_PriorityTask";
            this.btn_PriorityTask.Size = new System.Drawing.Size(199, 51);
            this.btn_PriorityTask.TabIndex = 3;
            this.btn_PriorityTask.Text = "Добавить приоритетную задачу";
            this.btn_PriorityTask.UseVisualStyleBackColor = true;
            // 
            // btn_ProgressTask
            // 
            this.btn_ProgressTask.Location = new System.Drawing.Point(21, 220);
            this.btn_ProgressTask.Name = "btn_ProgressTask";
            this.btn_ProgressTask.Size = new System.Drawing.Size(199, 49);
            this.btn_ProgressTask.TabIndex = 4;
            this.btn_ProgressTask.Text = "Добавить задачу-прогресс";
            this.btn_ProgressTask.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 769);
            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.sideMenuPanel);
            this.Name = "MainForm";
            this.Text = "Task Manager";
            this.sideMenuPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sideMenuPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel mainContentPanel;
        private System.Windows.Forms.Button btn_ProgressTask;
        private System.Windows.Forms.Button btn_PriorityTask;
        private System.Windows.Forms.Button btn_AddRecurringTask;
        private System.Windows.Forms.Button button1;
    }
}

