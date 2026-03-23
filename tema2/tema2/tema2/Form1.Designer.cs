namespace tema2
{
    partial class Form1
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
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.btnAddPoint = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.listBoxPoints = new System.Windows.Forms.ListBox();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.groupBoxInput.SuspendLayout();
            this.groupBoxList.SuspendLayout();
            this.groupBoxResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Controls.Add(this.btnClear);
            this.groupBoxInput.Controls.Add(this.btnAddPoint);
            this.groupBoxInput.Controls.Add(this.labelY);
            this.groupBoxInput.Controls.Add(this.labelX);
            this.groupBoxInput.Controls.Add(this.textBoxY);
            this.groupBoxInput.Controls.Add(this.textBoxX);
            this.groupBoxInput.Location = new System.Drawing.Point(23, 23);
            this.groupBoxInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxInput.Size = new System.Drawing.Size(350, 115);
            this.groupBoxInput.TabIndex = 0;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "Ввод новой точки";
            // 
            // textBoxX
            // 
            this.textBoxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBoxX.Location = new System.Drawing.Point(41, 31);
            this.textBoxX.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxX.MaxLength = 15;
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(116, 20);
            this.textBoxX.TabIndex = 0;
            // 
            // textBoxY
            // 
            this.textBoxY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxY.Location = new System.Drawing.Point(198, 31);
            this.textBoxY.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxY.MaxLength = 15;
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(116, 23);
            this.textBoxY.TabIndex = 1;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelX.Location = new System.Drawing.Point(12, 35);
            this.labelX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(21, 17);
            this.labelX.TabIndex = 2;
            this.labelX.Text = "X:";
            this.labelX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelY.Location = new System.Drawing.Point(169, 35);
            this.labelY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(21, 17);
            this.labelY.TabIndex = 3;
            this.labelY.Text = "Y:";
            this.labelY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAddPoint
            // 
            this.btnAddPoint.BackColor = System.Drawing.Color.LightGreen;
            this.btnAddPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddPoint.Location = new System.Drawing.Point(18, 69);
            this.btnAddPoint.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddPoint.Name = "btnAddPoint";
            this.btnAddPoint.Size = new System.Drawing.Size(140, 35);
            this.btnAddPoint.TabIndex = 4;
            this.btnAddPoint.Text = "Добавить";
            this.btnAddPoint.UseVisualStyleBackColor = false;
            this.btnAddPoint.Click += new System.EventHandler(this.btnAddPoint_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightCoral;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClear.Location = new System.Drawing.Point(198, 69);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(140, 35);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBoxList
            // 
            this.groupBoxList.Controls.Add(this.listBoxPoints);
            this.groupBoxList.Location = new System.Drawing.Point(23, 150);
            this.groupBoxList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxList.Size = new System.Drawing.Size(350, 231);
            this.groupBoxList.TabIndex = 1;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "Введенные точки";
            // 
            // listBoxPoints
            // 
            this.listBoxPoints.FormattingEnabled = true;
            this.listBoxPoints.IntegralHeight = false;
            this.listBoxPoints.ItemHeight = 15;
            this.listBoxPoints.Location = new System.Drawing.Point(8, 22);
            this.listBoxPoints.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listBoxPoints.Name = "listBoxPoints";
            this.listBoxPoints.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxPoints.Size = new System.Drawing.Size(326, 196);
            this.listBoxPoints.TabIndex = 2;
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxResult.Controls.Add(this.labelResult);
            this.groupBoxResult.Controls.Add(this.btnCalculate);
            this.groupBoxResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBoxResult.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.groupBoxResult.Location = new System.Drawing.Point(424, 23);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(320, 310);
            this.groupBoxResult.TabIndex = 2;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Результат поиска";
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.LightBlue;
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCalculate.Location = new System.Drawing.Point(14, 20);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(300, 40);
            this.btnCalculate.TabIndex = 0;
            this.btnCalculate.Text = "Найти ближайшие пары";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // labelResult
            // 
            this.labelResult.BackColor = System.Drawing.Color.White;
            this.labelResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelResult.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResult.Location = new System.Drawing.Point(10, 70);
            this.labelResult.Name = "labelResult";
            this.labelResult.Padding = new System.Windows.Forms.Padding(5);
            this.labelResult.Size = new System.Drawing.Size(300, 230);
            this.labelResult.TabIndex = 1;
            this.labelResult.Text = "Результат:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.groupBoxList);
            this.Controls.Add(this.groupBoxInput);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.groupBoxList.ResumeLayout(false);
            this.groupBoxResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAddPoint;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.ListBox listBoxPoints;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label labelResult;
    }
}

