namespace tema3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnStop = new Button();
            btnSettings = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // btnStop
            // 
            btnStop.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnStop.Location = new Point(86, 360);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(100, 40);
            btnStop.TabIndex = 0;
            btnStop.Text = "Стоп";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnSettings
            // 
            btnSettings.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSettings.Location = new Point(212, 360);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(100, 40);
            btnSettings.TabIndex = 1;
            btnSettings.Text = "Настройки";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(btnSettings);
            Controls.Add(btnStop);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Движение по периметру";
            Paint += Form1_Paint;
            Resize += Form1_Resize;
            ResumeLayout(false);
        }

        #endregion

        private Button btnStop;
        private Button btnSettings;
        private System.Windows.Forms.Timer timer1;
    }
}
