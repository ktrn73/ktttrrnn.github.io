namespace EnglishQuiz
{
    partial class frmGame
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
            this.lblQuestion = new System.Windows.Forms.Label();
            this.picQuestion = new System.Windows.Forms.PictureBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblTopicType = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblQuestion.Location = new System.Drawing.Point(20, 20);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(560, 60);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Здесь будет текст вопроса";
            // 
            // picQuestion
            // 
            this.picQuestion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQuestion.Location = new System.Drawing.Point(20, 90);
            this.picQuestion.Name = "picQuestion";
            this.picQuestion.Size = new System.Drawing.Size(250, 250);
            this.picQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQuestion.TabIndex = 1;
            this.picQuestion.TabStop = false;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblScore.Location = new System.Drawing.Point(21, 387);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(79, 21);
            this.lblScore.TabIndex = 7;
            this.lblScore.Text = "Баллы: 0";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTimer.ForeColor = System.Drawing.Color.Red;
            this.lblTimer.Location = new System.Drawing.Point(21, 357);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(109, 21);
            this.lblTimer.TabIndex = 8;
            this.lblTimer.Text = "Осталось: 60";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLevel.Location = new System.Drawing.Point(395, 13);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(85, 19);
            this.lblLevel.TabIndex = 10;
            this.lblLevel.Text = "Уровень: 1";
            // 
            // lblTopicType
            // 
            this.lblTopicType.AutoSize = true;
            this.lblTopicType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTopicType.ForeColor = System.Drawing.Color.Gray;
            this.lblTopicType.Location = new System.Drawing.Point(396, 42);
            this.lblTopicType.Name = "lblTopicType";
            this.lblTopicType.Size = new System.Drawing.Size(97, 15);
            this.lblTopicType.TabIndex = 11;
            this.lblTopicType.Text = "Тип: Анаграмма";
            // 
            // lblInstruction
            // 
            this.lblInstruction.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInstruction.ForeColor = System.Drawing.Color.Blue;
            this.lblInstruction.Location = new System.Drawing.Point(290, 120);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(280, 30);
            this.lblInstruction.TabIndex = 9;
            this.lblInstruction.Visible = false;
            // 
            // btnMenu
            // 
            this.btnMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMenu.Location = new System.Drawing.Point(520, 10);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(70, 25);
            this.btnMenu.TabIndex = 12;
            this.btnMenu.Text = "В меню";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // frmGame
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 500);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.lblTopicType);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.picQuestion);
            this.Controls.Add(this.lblQuestion);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EnglishQuiz — Тестирование";
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.PictureBox picQuestion;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblTopicType;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Button btnMenu;
    }
}