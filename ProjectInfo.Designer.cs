namespace IUL_Generate
{
    partial class ProjectInfo
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
            this.ProjectName_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GIP_tb = new System.Windows.Forms.TextBox();
            this.Developer_tb = new System.Windows.Forms.TextBox();
            this.GIP_dtp = new System.Windows.Forms.DateTimePicker();
            this.Developer_dtp = new System.Windows.Forms.DateTimePicker();
            this.OK_bt = new System.Windows.Forms.Button();
            this.Close_bt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProjectName_tb
            // 
            this.ProjectName_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProjectName_tb.Location = new System.Drawing.Point(15, 29);
            this.ProjectName_tb.Multiline = true;
            this.ProjectName_tb.Name = "ProjectName_tb";
            this.ProjectName_tb.Size = new System.Drawing.Size(315, 75);
            this.ProjectName_tb.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите наименование проекта без кавычек:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "ГИП: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Разраб.: ";
            // 
            // GIP_tb
            // 
            this.GIP_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GIP_tb.Location = new System.Drawing.Point(77, 122);
            this.GIP_tb.Name = "GIP_tb";
            this.GIP_tb.Size = new System.Drawing.Size(116, 21);
            this.GIP_tb.TabIndex = 4;
            // 
            // Developer_tb
            // 
            this.Developer_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Developer_tb.Location = new System.Drawing.Point(77, 157);
            this.Developer_tb.Name = "Developer_tb";
            this.Developer_tb.Size = new System.Drawing.Size(116, 21);
            this.Developer_tb.TabIndex = 5;
            // 
            // GIP_dtp
            // 
            this.GIP_dtp.Location = new System.Drawing.Point(211, 123);
            this.GIP_dtp.Name = "GIP_dtp";
            this.GIP_dtp.Size = new System.Drawing.Size(119, 20);
            this.GIP_dtp.TabIndex = 6;
            // 
            // Developer_dtp
            // 
            this.Developer_dtp.Location = new System.Drawing.Point(211, 158);
            this.Developer_dtp.Name = "Developer_dtp";
            this.Developer_dtp.Size = new System.Drawing.Size(119, 20);
            this.Developer_dtp.TabIndex = 7;
            // 
            // OK_bt
            // 
            this.OK_bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OK_bt.Location = new System.Drawing.Point(174, 198);
            this.OK_bt.Name = "OK_bt";
            this.OK_bt.Size = new System.Drawing.Size(75, 26);
            this.OK_bt.TabIndex = 8;
            this.OK_bt.Text = "ОК";
            this.OK_bt.UseVisualStyleBackColor = true;
            this.OK_bt.Click += new System.EventHandler(this.OK_bt_Click);
            // 
            // Close_bt
            // 
            this.Close_bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Close_bt.Location = new System.Drawing.Point(255, 198);
            this.Close_bt.Name = "Close_bt";
            this.Close_bt.Size = new System.Drawing.Size(75, 26);
            this.Close_bt.TabIndex = 9;
            this.Close_bt.Text = "Отмена";
            this.Close_bt.UseVisualStyleBackColor = true;
            this.Close_bt.Click += new System.EventHandler(this.Close_bt_Click);
            // 
            // ProjectInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 233);
            this.Controls.Add(this.Close_bt);
            this.Controls.Add(this.OK_bt);
            this.Controls.Add(this.Developer_dtp);
            this.Controls.Add(this.GIP_dtp);
            this.Controls.Add(this.Developer_tb);
            this.Controls.Add(this.GIP_tb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProjectName_tb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProjectInfo";
            this.Text = "Информация о проекте";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ProjectName_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox GIP_tb;
        private System.Windows.Forms.TextBox Developer_tb;
        private System.Windows.Forms.DateTimePicker GIP_dtp;
        private System.Windows.Forms.DateTimePicker Developer_dtp;
        private System.Windows.Forms.Button OK_bt;
        private System.Windows.Forms.Button Close_bt;
    }
}