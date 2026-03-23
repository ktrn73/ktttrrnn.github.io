namespace tema3
{
    partial class SettingsForm
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
            btnSelectColor = new Button();
            colorDialog1 = new ColorDialog();
            trackBarSpeed = new TrackBar();
            groupBox1 = new GroupBox();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBarSpeed).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSelectColor
            // 
            btnSelectColor.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSelectColor.Location = new Point(107, 139);
            btnSelectColor.Name = "btnSelectColor";
            btnSelectColor.Size = new Size(150, 30);
            btnSelectColor.TabIndex = 0;
            btnSelectColor.Text = "Выбрать цвет...";
            btnSelectColor.UseVisualStyleBackColor = true;
            btnSelectColor.Click += btnSelectColor_Click;
            // 
            // colorDialog1
            // 
            colorDialog1.Color = Color.Red;
            // 
            // trackBarSpeed
            // 
            trackBarSpeed.Location = new Point(6, 22);
            trackBarSpeed.Minimum = 1;
            trackBarSpeed.Name = "trackBarSpeed";
            trackBarSpeed.Size = new Size(300, 45);
            trackBarSpeed.TabIndex = 1;
            trackBarSpeed.Value = 5;
            trackBarSpeed.Scroll += trackBarSpeed_Scroll;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(trackBarSpeed);
            groupBox1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(12, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(334, 90);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Скорость движения";
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSave.Location = new Point(18, 209);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 30);
            btnSave.TabIndex = 3;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(226, 209);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 30);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // SettingsForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(367, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(groupBox1);
            Controls.Add(btnSelectColor);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Настройки параметров";
            ((System.ComponentModel.ISupportInitialize)trackBarSpeed).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSelectColor;
        private ColorDialog colorDialog1;
        private TrackBar trackBarSpeed;
        private GroupBox groupBox1;
        private Button btnSave;
        private Button btnCancel;
    }
}