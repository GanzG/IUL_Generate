namespace IUL_Generate
{
    partial class MainView
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
            this.label1 = new System.Windows.Forms.Label();
            this.FolderPath_tb = new System.Windows.Forms.TextBox();
            this.Browse_bt = new System.Windows.Forms.Button();
            this.FilesWithCRC32_DGV = new System.Windows.Forms.DataGridView();
            this.Close_bt = new System.Windows.Forms.Button();
            this.CreateWordFile_bt = new System.Windows.Forms.Button();
            this.BrowseFolderWithFiles_fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.SaveWordFileDialog_sfd = new System.Windows.Forms.SaveFileDialog();
            this.Action_PrB = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.FilesWithCRC32_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите путь до папки с файлами";
            // 
            // FolderPath_tb
            // 
            this.FolderPath_tb.Location = new System.Drawing.Point(15, 30);
            this.FolderPath_tb.Name = "FolderPath_tb";
            this.FolderPath_tb.ReadOnly = true;
            this.FolderPath_tb.Size = new System.Drawing.Size(323, 20);
            this.FolderPath_tb.TabIndex = 1;
            // 
            // Browse_bt
            // 
            this.Browse_bt.Location = new System.Drawing.Point(344, 30);
            this.Browse_bt.Name = "Browse_bt";
            this.Browse_bt.Size = new System.Drawing.Size(69, 20);
            this.Browse_bt.TabIndex = 2;
            this.Browse_bt.Text = "Обзор...";
            this.Browse_bt.UseVisualStyleBackColor = true;
            this.Browse_bt.Click += new System.EventHandler(this.Browse_bt_Click);
            // 
            // FilesWithCRC32_DGV
            // 
            this.FilesWithCRC32_DGV.AllowUserToAddRows = false;
            this.FilesWithCRC32_DGV.AllowUserToDeleteRows = false;
            this.FilesWithCRC32_DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FilesWithCRC32_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FilesWithCRC32_DGV.ColumnHeadersVisible = false;
            this.FilesWithCRC32_DGV.Location = new System.Drawing.Point(15, 56);
            this.FilesWithCRC32_DGV.Name = "FilesWithCRC32_DGV";
            this.FilesWithCRC32_DGV.RowHeadersVisible = false;
            this.FilesWithCRC32_DGV.Size = new System.Drawing.Size(398, 201);
            this.FilesWithCRC32_DGV.TabIndex = 3;
            // 
            // Close_bt
            // 
            this.Close_bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Close_bt.Location = new System.Drawing.Point(331, 263);
            this.Close_bt.Name = "Close_bt";
            this.Close_bt.Size = new System.Drawing.Size(82, 26);
            this.Close_bt.TabIndex = 4;
            this.Close_bt.Text = "Выход";
            this.Close_bt.UseVisualStyleBackColor = true;
            this.Close_bt.Click += new System.EventHandler(this.Close_bt_Click);
            // 
            // CreateWordFile_bt
            // 
            this.CreateWordFile_bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateWordFile_bt.Location = new System.Drawing.Point(166, 263);
            this.CreateWordFile_bt.Name = "CreateWordFile_bt";
            this.CreateWordFile_bt.Size = new System.Drawing.Size(159, 26);
            this.CreateWordFile_bt.TabIndex = 5;
            this.CreateWordFile_bt.Text = "Создать Word-файл";
            this.CreateWordFile_bt.UseVisualStyleBackColor = true;
            this.CreateWordFile_bt.Click += new System.EventHandler(this.CreateWordFile_bt_Click);
            // 
            // Action_PrB
            // 
            this.Action_PrB.Location = new System.Drawing.Point(15, 266);
            this.Action_PrB.Name = "Action_PrB";
            this.Action_PrB.Size = new System.Drawing.Size(145, 20);
            this.Action_PrB.TabIndex = 6;
            this.Action_PrB.Visible = false;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 299);
            this.Controls.Add(this.Action_PrB);
            this.Controls.Add(this.CreateWordFile_bt);
            this.Controls.Add(this.Close_bt);
            this.Controls.Add(this.FilesWithCRC32_DGV);
            this.Controls.Add(this.Browse_bt);
            this.Controls.Add(this.FolderPath_tb);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MainView";
            this.Text = "Генерация ИУЛ";
            ((System.ComponentModel.ISupportInitialize)(this.FilesWithCRC32_DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FolderPath_tb;
        private System.Windows.Forms.Button Browse_bt;
        private System.Windows.Forms.DataGridView FilesWithCRC32_DGV;
        private System.Windows.Forms.Button Close_bt;
        private System.Windows.Forms.Button CreateWordFile_bt;
        private System.Windows.Forms.FolderBrowserDialog BrowseFolderWithFiles_fbd;
        private System.Windows.Forms.SaveFileDialog SaveWordFileDialog_sfd;
        private System.Windows.Forms.ProgressBar Action_PrB;
    }
}

