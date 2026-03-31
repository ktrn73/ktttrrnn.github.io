namespace EnglishQuiz
{
    partial class frmAdmin
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
            this.lblTopic = new System.Windows.Forms.Label();
            this.txtTopic = new System.Windows.Forms.TextBox();
            this.btnAddTopic = new System.Windows.Forms.Button();
            this.lblLevel = new System.Windows.Forms.Label();
            this.numLevel = new System.Windows.Forms.NumericUpDown();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.lblImagePath = new System.Windows.Forms.Label();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.lblAnswers = new System.Windows.Forms.Label();
            this.txtAnswer1 = new System.Windows.Forms.TextBox();
            this.txtAnswer2 = new System.Windows.Forms.TextBox();
            this.txtAnswer3 = new System.Windows.Forms.TextBox();
            this.txtAnswer4 = new System.Windows.Forms.TextBox();
            this.chkRight1 = new System.Windows.Forms.CheckBox();
            this.chkRight2 = new System.Windows.Forms.CheckBox();
            this.chkRight3 = new System.Windows.Forms.CheckBox();
            this.chkRight4 = new System.Windows.Forms.CheckBox();
            this.btnSaveQuestion = new System.Windows.Forms.Button();
            this.cmbExistingTopics = new System.Windows.Forms.ComboBox();
            this.lblOr = new System.Windows.Forms.Label();
            this.lblSelectTopic = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxNewTopic = new System.Windows.Forms.GroupBox();
            this.cmbTopicTypeForQuestion = new System.Windows.Forms.ComboBox();
            this.lblTopicType = new System.Windows.Forms.Label();
            this.groupBoxAddQuestion = new System.Windows.Forms.GroupBox();
            this.groupBoxNewTopic.SuspendLayout();
            this.groupBoxAddQuestion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTopic
            // 
            this.lblTopic.AutoSize = true;
            this.lblTopic.Location = new System.Drawing.Point(10, 30);
            this.lblTopic.Name = "lblTopic";
            this.lblTopic.Size = new System.Drawing.Size(94, 15);
            this.lblTopic.TabIndex = 0;
            this.lblTopic.Text = "Название темы:";
            // 
            // txtTopic
            // 
            this.txtTopic.Location = new System.Drawing.Point(110, 27);
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.Size = new System.Drawing.Size(180, 23);
            this.txtTopic.TabIndex = 1;
            // 
            // lblTopicType
            // 
            this.lblTopicType.AutoSize = true;
            this.lblTopicType.Location = new System.Drawing.Point(10, 60);
            this.lblTopicType.Name = "lblTopicType";
            this.lblTopicType.Size = new System.Drawing.Size(86, 15);
            this.lblTopicType.TabIndex = 20;
            this.lblTopicType.Text = "Тип заданий:";
            // 
            // cmbTopicTypeForQuestion
            // 
            this.cmbTopicTypeForQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTopicTypeForQuestion.FormattingEnabled = true;
            this.cmbTopicTypeForQuestion.Items.AddRange(new object[] {
            "anagram",
            "translation",
            "fillblank"});
            this.cmbTopicTypeForQuestion.Location = new System.Drawing.Point(110, 57);
            this.cmbTopicTypeForQuestion.Name = "cmbTopicTypeForQuestion";
            this.cmbTopicTypeForQuestion.Size = new System.Drawing.Size(180, 23);
            this.cmbTopicTypeForQuestion.TabIndex = 21;
            // 
            // btnAddTopic
            // 
            this.btnAddTopic.Location = new System.Drawing.Point(310, 40);
            this.btnAddTopic.Name = "btnAddTopic";
            this.btnAddTopic.Size = new System.Drawing.Size(130, 40);
            this.btnAddTopic.TabIndex = 2;
            this.btnAddTopic.Text = "Создать тему";
            this.btnAddTopic.UseVisualStyleBackColor = true;
            this.btnAddTopic.Click += new System.EventHandler(this.btnAddTopic_Click);
            // 
            // groupBoxNewTopic
            // 
            this.groupBoxNewTopic.Controls.Add(this.lblTopic);
            this.groupBoxNewTopic.Controls.Add(this.txtTopic);
            this.groupBoxNewTopic.Controls.Add(this.lblTopicType);
            this.groupBoxNewTopic.Controls.Add(this.cmbTopicTypeForQuestion);
            this.groupBoxNewTopic.Controls.Add(this.btnAddTopic);
            this.groupBoxNewTopic.Location = new System.Drawing.Point(12, 12);
            this.groupBoxNewTopic.Name = "groupBoxNewTopic";
            this.groupBoxNewTopic.Size = new System.Drawing.Size(460, 90);
            this.groupBoxNewTopic.TabIndex = 0;
            this.groupBoxNewTopic.TabStop = false;
            this.groupBoxNewTopic.Text = "Создать новую тему";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(10, 30);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(120, 15);
            this.lblLevel.TabIndex = 0;
            this.lblLevel.Text = "Уровень сложности:";
            // 
            // numLevel
            // 
            this.numLevel.Location = new System.Drawing.Point(150, 28);
            this.numLevel.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            this.numLevel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numLevel.Name = "numLevel";
            this.numLevel.Size = new System.Drawing.Size(60, 23);
            this.numLevel.TabIndex = 1;
            this.numLevel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(10, 65);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(51, 15);
            this.lblQuestion.TabIndex = 2;
            this.lblQuestion.Text = "Вопрос:";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(10, 85);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(440, 60);
            this.txtQuestion.TabIndex = 3;
            // 
            // lblImagePath
            // 
            this.lblImagePath.AutoSize = true;
            this.lblImagePath.Location = new System.Drawing.Point(10, 160);
            this.lblImagePath.Name = "lblImagePath";
            this.lblImagePath.Size = new System.Drawing.Size(98, 15);
            this.lblImagePath.TabIndex = 4;
            this.lblImagePath.Text = "Путь к картинке:";
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(10, 180);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(350, 23);
            this.txtImagePath.TabIndex = 5;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Location = new System.Drawing.Point(370, 179);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(80, 25);
            this.btnBrowseImage.TabIndex = 6;
            this.btnBrowseImage.Text = "Обзор";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // lblAnswers
            // 
            this.lblAnswers.AutoSize = true;
            this.lblAnswers.Location = new System.Drawing.Point(10, 220);
            this.lblAnswers.Name = "lblAnswers";
            this.lblAnswers.Size = new System.Drawing.Size(109, 15);
            this.lblAnswers.TabIndex = 7;
            this.lblAnswers.Text = "Варианты ответов:";
            // 
            // txtAnswer1
            // 
            this.txtAnswer1.Location = new System.Drawing.Point(10, 245);
            this.txtAnswer1.Name = "txtAnswer1";
            this.txtAnswer1.Size = new System.Drawing.Size(350, 23);
            this.txtAnswer1.TabIndex = 8;
            // 
            // txtAnswer2
            // 
            this.txtAnswer2.Location = new System.Drawing.Point(10, 275);
            this.txtAnswer2.Name = "txtAnswer2";
            this.txtAnswer2.Size = new System.Drawing.Size(350, 23);
            this.txtAnswer2.TabIndex = 9;
            // 
            // txtAnswer3
            // 
            this.txtAnswer3.Location = new System.Drawing.Point(10, 305);
            this.txtAnswer3.Name = "txtAnswer3";
            this.txtAnswer3.Size = new System.Drawing.Size(350, 23);
            this.txtAnswer3.TabIndex = 10;
            // 
            // txtAnswer4
            // 
            this.txtAnswer4.Location = new System.Drawing.Point(10, 335);
            this.txtAnswer4.Name = "txtAnswer4";
            this.txtAnswer4.Size = new System.Drawing.Size(350, 23);
            this.txtAnswer4.TabIndex = 11;
            // 
            // chkRight1
            // 
            this.chkRight1.AutoSize = true;
            this.chkRight1.Location = new System.Drawing.Point(370, 248);
            this.chkRight1.Name = "chkRight1";
            this.chkRight1.Size = new System.Drawing.Size(97, 19);
            this.chkRight1.TabIndex = 12;
            this.chkRight1.Text = "Правильный";
            // 
            // chkRight2
            // 
            this.chkRight2.AutoSize = true;
            this.chkRight2.Location = new System.Drawing.Point(370, 278);
            this.chkRight2.Name = "chkRight2";
            this.chkRight2.Size = new System.Drawing.Size(97, 19);
            this.chkRight2.TabIndex = 13;
            this.chkRight2.Text = "Правильный";
            // 
            // chkRight3
            // 
            this.chkRight3.AutoSize = true;
            this.chkRight3.Location = new System.Drawing.Point(370, 308);
            this.chkRight3.Name = "chkRight3";
            this.chkRight3.Size = new System.Drawing.Size(97, 19);
            this.chkRight3.TabIndex = 14;
            this.chkRight3.Text = "Правильный";
            // 
            // chkRight4
            // 
            this.chkRight4.AutoSize = true;
            this.chkRight4.Location = new System.Drawing.Point(370, 338);
            this.chkRight4.Name = "chkRight4";
            this.chkRight4.Size = new System.Drawing.Size(97, 19);
            this.chkRight4.TabIndex = 15;
            this.chkRight4.Text = "Правильный";
            // 
            // btnSaveQuestion
            // 
            this.btnSaveQuestion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveQuestion.Location = new System.Drawing.Point(130, 380);
            this.btnSaveQuestion.Name = "btnSaveQuestion";
            this.btnSaveQuestion.Size = new System.Drawing.Size(200, 35);
            this.btnSaveQuestion.TabIndex = 16;
            this.btnSaveQuestion.Text = "Сохранить вопрос";
            this.btnSaveQuestion.UseVisualStyleBackColor = true;
            this.btnSaveQuestion.Click += new System.EventHandler(this.btnSaveQuestion_Click);
            // 
            // cmbExistingTopics
            // 
            this.cmbExistingTopics.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExistingTopics.FormattingEnabled = true;
            this.cmbExistingTopics.Location = new System.Drawing.Point(110, 25);
            this.cmbExistingTopics.Name = "cmbExistingTopics";
            this.cmbExistingTopics.Size = new System.Drawing.Size(200, 23);
            this.cmbExistingTopics.TabIndex = 21;
            this.cmbExistingTopics.SelectedIndexChanged += new System.EventHandler(this.cmbExistingTopics_SelectedIndexChanged);
            // 
            // lblOr
            // 
            this.lblOr.AutoSize = true;
            this.lblOr.Location = new System.Drawing.Point(320, 28);
            this.lblOr.Name = "lblOr";
            this.lblOr.Size = new System.Drawing.Size(36, 15);
            this.lblOr.TabIndex = 22;
            this.lblOr.Text = "(или)";
            // 
            // lblSelectTopic
            // 
            this.lblSelectTopic.AutoSize = true;
            this.lblSelectTopic.Location = new System.Drawing.Point(10, 28);
            this.lblSelectTopic.Name = "lblSelectTopic";
            this.lblSelectTopic.Size = new System.Drawing.Size(93, 15);
            this.lblSelectTopic.TabIndex = 20;
            this.lblSelectTopic.Text = "Выберите тему:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            this.openFileDialog.Title = "Выберите изображение";
            // 
            // groupBoxAddQuestion
            // 
            this.groupBoxAddQuestion.Controls.Add(this.lblSelectTopic);
            this.groupBoxAddQuestion.Controls.Add(this.cmbExistingTopics);
            this.groupBoxAddQuestion.Controls.Add(this.lblOr);
            this.groupBoxAddQuestion.Controls.Add(this.lblLevel);
            this.groupBoxAddQuestion.Controls.Add(this.numLevel);
            this.groupBoxAddQuestion.Controls.Add(this.lblQuestion);
            this.groupBoxAddQuestion.Controls.Add(this.txtQuestion);
            this.groupBoxAddQuestion.Controls.Add(this.lblImagePath);
            this.groupBoxAddQuestion.Controls.Add(this.txtImagePath);
            this.groupBoxAddQuestion.Controls.Add(this.btnBrowseImage);
            this.groupBoxAddQuestion.Controls.Add(this.lblAnswers);
            this.groupBoxAddQuestion.Controls.Add(this.txtAnswer1);
            this.groupBoxAddQuestion.Controls.Add(this.txtAnswer2);
            this.groupBoxAddQuestion.Controls.Add(this.txtAnswer3);
            this.groupBoxAddQuestion.Controls.Add(this.txtAnswer4);
            this.groupBoxAddQuestion.Controls.Add(this.chkRight1);
            this.groupBoxAddQuestion.Controls.Add(this.chkRight2);
            this.groupBoxAddQuestion.Controls.Add(this.chkRight3);
            this.groupBoxAddQuestion.Controls.Add(this.chkRight4);
            this.groupBoxAddQuestion.Controls.Add(this.btnSaveQuestion);
            this.groupBoxAddQuestion.Location = new System.Drawing.Point(12, 110);
            this.groupBoxAddQuestion.Name = "groupBoxAddQuestion";
            this.groupBoxAddQuestion.Size = new System.Drawing.Size(472, 430);
            this.groupBoxAddQuestion.TabIndex = 1;
            this.groupBoxAddQuestion.TabStop = false;
            this.groupBoxAddQuestion.Text = "Добавить вопрос";
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 555);
            this.Controls.Add(this.groupBoxAddQuestion);
            this.Controls.Add(this.groupBoxNewTopic);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Панель администратора";
            this.groupBoxNewTopic.ResumeLayout(false);
            this.groupBoxNewTopic.PerformLayout();
            this.groupBoxAddQuestion.ResumeLayout(false);
            this.groupBoxAddQuestion.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblTopic;
        private System.Windows.Forms.TextBox txtTopic;
        private System.Windows.Forms.Button btnAddTopic;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.NumericUpDown numLevel;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Label lblImagePath;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Label lblAnswers;
        private System.Windows.Forms.TextBox txtAnswer1;
        private System.Windows.Forms.TextBox txtAnswer2;
        private System.Windows.Forms.TextBox txtAnswer3;
        private System.Windows.Forms.TextBox txtAnswer4;
        private System.Windows.Forms.CheckBox chkRight1;
        private System.Windows.Forms.CheckBox chkRight2;
        private System.Windows.Forms.CheckBox chkRight3;
        private System.Windows.Forms.CheckBox chkRight4;
        private System.Windows.Forms.Button btnSaveQuestion;
        private System.Windows.Forms.ComboBox cmbExistingTopics;
        private System.Windows.Forms.Label lblOr;
        private System.Windows.Forms.Label lblSelectTopic;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox groupBoxNewTopic;
        private System.Windows.Forms.GroupBox groupBoxAddQuestion;
        private System.Windows.Forms.ComboBox cmbTopicTypeForQuestion;
        private System.Windows.Forms.Label lblTopicType;
    }
}