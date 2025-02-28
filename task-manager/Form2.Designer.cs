using System;
using System.Reflection;

namespace task_manager
{
    partial class wTaskCreator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbTaskType = new System.Windows.Forms.ComboBox();
            this.lTaskType = new System.Windows.Forms.Label();
            this.tbTaskName = new System.Windows.Forms.TextBox();
            this.tbTaskDescription = new System.Windows.Forms.TextBox();
            this.lTaskName = new System.Windows.Forms.Label();
            this.lDescription = new System.Windows.Forms.Label();
            this.lTitile = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbTaskType
            // 
            this.cbTaskType.FormattingEnabled = true;

            foreach (var type in TaskManagerModel.TaskTypes) {
                this.cbTaskType.Items.Add((string) type.GetField("taskTypeName").GetValue(null));
            }

            this.cbTaskType.Location = new System.Drawing.Point(189, 60);
            this.cbTaskType.Name = "cbTaskType";
            this.cbTaskType.Size = new System.Drawing.Size(362, 24);
            this.cbTaskType.TabIndex = 0;
            // 
            // lTaskType
            // 
            this.lTaskType.AutoSize = true;
            this.lTaskType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lTaskType.Location = new System.Drawing.Point(52, 60);
            this.lTaskType.Name = "lTaskType";
            this.lTaskType.Size = new System.Drawing.Size(90, 20);
            this.lTaskType.TabIndex = 1;
            this.lTaskType.Text = "Task type";
            // 
            // tbTaskName
            // 
            this.tbTaskName.Location = new System.Drawing.Point(189, 109);
            this.tbTaskName.Name = "tbTaskName";
            this.tbTaskName.Size = new System.Drawing.Size(362, 22);
            this.tbTaskName.TabIndex = 2;
            // 
            // tbTaskDescription
            // 
            this.tbTaskDescription.Location = new System.Drawing.Point(189, 138);
            this.tbTaskDescription.Multiline = true;
            this.tbTaskDescription.Name = "tbTaskDescription";
            this.tbTaskDescription.Size = new System.Drawing.Size(362, 96);
            this.tbTaskDescription.TabIndex = 3;
            // 
            // lTaskName
            // 
            this.lTaskName.AutoSize = true;
            this.lTaskName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lTaskName.Location = new System.Drawing.Point(52, 109);
            this.lTaskName.Name = "lTaskName";
            this.lTaskName.Size = new System.Drawing.Size(100, 20);
            this.lTaskName.TabIndex = 4;
            this.lTaskName.Text = "Task name";
            // 
            // lDescription
            // 
            this.lDescription.AutoSize = true;
            this.lDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lDescription.Location = new System.Drawing.Point(52, 138);
            this.lDescription.Name = "lDescription";
            this.lDescription.Size = new System.Drawing.Size(106, 20);
            this.lDescription.TabIndex = 5;
            this.lDescription.Text = "Description";
            // 
            // lTitile
            // 
            this.lTitile.AutoSize = true;
            this.lTitile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lTitile.Location = new System.Drawing.Point(198, 9);
            this.lTitile.Name = "lTitile";
            this.lTitile.Size = new System.Drawing.Size(200, 29);
            this.lTitile.TabIndex = 6;
            this.lTitile.Text = "Create new task";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(25, 528);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 27);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Location = new System.Drawing.Point(164, 528);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(133, 27);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(470, 528);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(133, 27);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // wTaskCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 567);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lTitile);
            this.Controls.Add(this.lDescription);
            this.Controls.Add(this.lTaskName);
            this.Controls.Add(this.tbTaskDescription);
            this.Controls.Add(this.tbTaskName);
            this.Controls.Add(this.lTaskType);
            this.Controls.Add(this.cbTaskType);
            this.Name = "wTaskCreator";
            this.Text = "Task creator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTaskType;
        private System.Windows.Forms.Label lTaskType;
        private System.Windows.Forms.TextBox tbTaskName;
        private System.Windows.Forms.TextBox tbTaskDescription;
        private System.Windows.Forms.Label lTaskName;
        private System.Windows.Forms.Label lDescription;
        private System.Windows.Forms.Label lTitile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnConfirm;
    }
}