namespace EnglishQuiz
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSelectTopic = new System.Windows.Forms.Label();
            this.cmbTopic = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(50, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(379, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "EnglishQuiz — Изучение языка";
            // 
            // lblSelectTopic
            // 
            this.lblSelectTopic.AutoSize = true;
            this.lblSelectTopic.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSelectTopic.Location = new System.Drawing.Point(50, 90);
            this.lblSelectTopic.Name = "lblSelectTopic";
            this.lblSelectTopic.Size = new System.Drawing.Size(121, 21);
            this.lblSelectTopic.TabIndex = 1;
            this.lblSelectTopic.Text = "Выберите тему:";
            // 
            // cmbTopic
            // 
            this.cmbTopic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTopic.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbTopic.FormattingEnabled = true;
            this.cmbTopic.Location = new System.Drawing.Point(50, 120);
            this.cmbTopic.Name = "cmbTopic";
            this.cmbTopic.Size = new System.Drawing.Size(340, 29);
            this.cmbTopic.TabIndex = 2;
            this.cmbTopic.SelectedIndexChanged += new System.EventHandler(this.cmbTopic_SelectedIndexChanged);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnStart.Location = new System.Drawing.Point(50, 170);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(160, 54);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Начать тест";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAdmin.Location = new System.Drawing.Point(230, 170);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(160, 54);
            this.btnAdmin.TabIndex = 4;
            this.btnAdmin.Text = "Панель администратора";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatus.Location = new System.Drawing.Point(50, 230);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(179, 19);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Выберите тему для начала";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 313);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cmbTopic);
            this.Controls.Add(this.lblSelectTopic);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EnglishQuiz — Главное меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSelectTopic;
        private System.Windows.Forms.ComboBox cmbTopic;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Label lblStatus;
    }
}