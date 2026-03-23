namespace DictionaryApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.GroupBox groupBoxDictionary;
        private System.Windows.Forms.GroupBox groupBoxView;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.GroupBox groupBoxResults;
        private System.Windows.Forms.ListBox listBoxWords;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label lblPrefix;
        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.Button btnAddWord;
        private System.Windows.Forms.Button btnRemoveWord;
        private System.Windows.Forms.Button btnLoadDictionary;
        private System.Windows.Forms.Button btnCreateCustomDict;
        private System.Windows.Forms.Button btnDeleteCustomDict;
        private System.Windows.Forms.Button btnSaveDictionary;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.TextBox txtExcludeLetters;
        private System.Windows.Forms.Label lblExcludeLetters;
        private System.Windows.Forms.Button btnSearchVariant;
        private System.Windows.Forms.TextBox txtFuzzyPattern;
        private System.Windows.Forms.Label lblFuzzyPattern;
        private System.Windows.Forms.Button btnFuzzySearch;
        private System.Windows.Forms.TextBox txtSearchResults;
        private System.Windows.Forms.Button btnSaveResults;
        private System.Windows.Forms.Button btnClearResults;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxDictionary = new System.Windows.Forms.GroupBox();
            this.btnSaveDictionary = new System.Windows.Forms.Button();
            this.btnDeleteCustomDict = new System.Windows.Forms.Button();
            this.btnCreateCustomDict = new System.Windows.Forms.Button();
            this.btnLoadDictionary = new System.Windows.Forms.Button();
            this.btnRemoveWord = new System.Windows.Forms.Button();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.groupBoxView = new System.Windows.Forms.GroupBox();
            this.listBoxWords = new System.Windows.Forms.ListBox();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.lblPrefix = new System.Windows.Forms.Label();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.btnFuzzySearch = new System.Windows.Forms.Button();
            this.txtFuzzyPattern = new System.Windows.Forms.TextBox();
            this.lblFuzzyPattern = new System.Windows.Forms.Label();
            this.btnSearchVariant = new System.Windows.Forms.Button();
            this.txtExcludeLetters = new System.Windows.Forms.TextBox();
            this.lblExcludeLetters = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.groupBoxResults = new System.Windows.Forms.GroupBox();
            this.btnClearResults = new System.Windows.Forms.Button();
            this.btnSaveResults = new System.Windows.Forms.Button();
            this.txtSearchResults = new System.Windows.Forms.TextBox();
            this.statusStrip.SuspendLayout();
            this.groupBoxDictionary.SuspendLayout();
            this.groupBoxView.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            this.groupBoxResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 528);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(884, 22);
            this.statusStrip.TabIndex = 0;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel.Text = "Готов";
            // 
            // groupBoxDictionary
            // 
            this.groupBoxDictionary.Controls.Add(this.btnSaveDictionary);
            this.groupBoxDictionary.Controls.Add(this.btnDeleteCustomDict);
            this.groupBoxDictionary.Controls.Add(this.btnCreateCustomDict);
            this.groupBoxDictionary.Controls.Add(this.btnLoadDictionary);
            this.groupBoxDictionary.Controls.Add(this.btnRemoveWord);
            this.groupBoxDictionary.Controls.Add(this.btnAddWord);
            this.groupBoxDictionary.Controls.Add(this.txtWord);
            this.groupBoxDictionary.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDictionary.Name = "groupBoxDictionary";
            this.groupBoxDictionary.Size = new System.Drawing.Size(280, 252);
            this.groupBoxDictionary.TabIndex = 1;
            this.groupBoxDictionary.TabStop = false;
            this.groupBoxDictionary.Text = "Работа со словарём";
            // 
            // btnSaveDictionary
            // 
            this.btnSaveDictionary.Location = new System.Drawing.Point(10, 215);
            this.btnSaveDictionary.Name = "btnSaveDictionary";
            this.btnSaveDictionary.Size = new System.Drawing.Size(260, 30);
            this.btnSaveDictionary.TabIndex = 6;
            this.btnSaveDictionary.Text = "Сохранить словарь";
            this.btnSaveDictionary.UseVisualStyleBackColor = true;
            this.btnSaveDictionary.Click += new System.EventHandler(this.btnSaveDictionary_Click);
            // 
            // btnDeleteCustomDict
            // 
            this.btnDeleteCustomDict.Location = new System.Drawing.Point(145, 175);
            this.btnDeleteCustomDict.Name = "btnDeleteCustomDict";
            this.btnDeleteCustomDict.Size = new System.Drawing.Size(125, 35);
            this.btnDeleteCustomDict.TabIndex = 5;
            this.btnDeleteCustomDict.Text = "Удалить свой словарь";
            this.btnDeleteCustomDict.UseVisualStyleBackColor = true;
            this.btnDeleteCustomDict.Click += new System.EventHandler(this.btnDeleteCustomDict_Click);
            // 
            // btnCreateCustomDict
            // 
            this.btnCreateCustomDict.Location = new System.Drawing.Point(10, 175);
            this.btnCreateCustomDict.Name = "btnCreateCustomDict";
            this.btnCreateCustomDict.Size = new System.Drawing.Size(125, 35);
            this.btnCreateCustomDict.TabIndex = 4;
            this.btnCreateCustomDict.Text = "Создать свой словарь";
            this.btnCreateCustomDict.UseVisualStyleBackColor = true;
            this.btnCreateCustomDict.Click += new System.EventHandler(this.btnCreateCustomDict_Click);
            // 
            // btnLoadDictionary
            // 
            this.btnLoadDictionary.Location = new System.Drawing.Point(10, 135);
            this.btnLoadDictionary.Name = "btnLoadDictionary";
            this.btnLoadDictionary.Size = new System.Drawing.Size(260, 30);
            this.btnLoadDictionary.TabIndex = 3;
            this.btnLoadDictionary.Text = "Загрузить словарь";
            this.btnLoadDictionary.UseVisualStyleBackColor = true;
            this.btnLoadDictionary.Click += new System.EventHandler(this.btnLoadDictionary_Click);
            // 
            // btnRemoveWord
            // 
            this.btnRemoveWord.Location = new System.Drawing.Point(10, 95);
            this.btnRemoveWord.Name = "btnRemoveWord";
            this.btnRemoveWord.Size = new System.Drawing.Size(260, 30);
            this.btnRemoveWord.TabIndex = 2;
            this.btnRemoveWord.Text = "Удалить выбранное слово";
            this.btnRemoveWord.UseVisualStyleBackColor = true;
            this.btnRemoveWord.Click += new System.EventHandler(this.btnRemoveWord_Click);
            // 
            // btnAddWord
            // 
            this.btnAddWord.Location = new System.Drawing.Point(10, 55);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(260, 30);
            this.btnAddWord.TabIndex = 1;
            this.btnAddWord.Text = "Добавить слово";
            this.btnAddWord.UseVisualStyleBackColor = true;
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // txtWord
            // 
            this.txtWord.Location = new System.Drawing.Point(10, 25);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(260, 20);
            this.txtWord.TabIndex = 0;
            // 
            // groupBoxView
            // 
            this.groupBoxView.Controls.Add(this.listBoxWords);
            this.groupBoxView.Controls.Add(this.txtPrefix);
            this.groupBoxView.Controls.Add(this.lblPrefix);
            this.groupBoxView.Location = new System.Drawing.Point(302, 12);
            this.groupBoxView.Name = "groupBoxView";
            this.groupBoxView.Size = new System.Drawing.Size(280, 270);
            this.groupBoxView.TabIndex = 2;
            this.groupBoxView.TabStop = false;
            this.groupBoxView.Text = "Просмотр словаря";
            // 
            // listBoxWords
            // 
            this.listBoxWords.FormattingEnabled = true;
            this.listBoxWords.Location = new System.Drawing.Point(10, 75);
            this.listBoxWords.Name = "listBoxWords";
            this.listBoxWords.Size = new System.Drawing.Size(260, 160);
            this.listBoxWords.TabIndex = 2;
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(10, 45);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(260, 20);
            this.txtPrefix.TabIndex = 1;
            this.txtPrefix.Click += new System.EventHandler(this.txtPrefix_TextChanged);
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Location = new System.Drawing.Point(10, 25);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(132, 13);
            this.lblPrefix.TabIndex = 0;
            this.lblPrefix.Text = "Начинается с (префикс):";
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.btnFuzzySearch);
            this.groupBoxSearch.Controls.Add(this.txtFuzzyPattern);
            this.groupBoxSearch.Controls.Add(this.lblFuzzyPattern);
            this.groupBoxSearch.Controls.Add(this.btnSearchVariant);
            this.groupBoxSearch.Controls.Add(this.txtExcludeLetters);
            this.groupBoxSearch.Controls.Add(this.lblExcludeLetters);
            this.groupBoxSearch.Controls.Add(this.txtLength);
            this.groupBoxSearch.Controls.Add(this.lblLength);
            this.groupBoxSearch.Location = new System.Drawing.Point(12, 277);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(280, 190);
            this.groupBoxSearch.TabIndex = 3;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Поиск";
            // 
            // btnFuzzySearch
            // 
            this.btnFuzzySearch.Location = new System.Drawing.Point(170, 162);
            this.btnFuzzySearch.Name = "btnFuzzySearch";
            this.btnFuzzySearch.Size = new System.Drawing.Size(100, 25);
            this.btnFuzzySearch.TabIndex = 7;
            this.btnFuzzySearch.Text = "Найти";
            this.btnFuzzySearch.UseVisualStyleBackColor = true;
            this.btnFuzzySearch.Click += new System.EventHandler(this.btnFuzzySearch_Click);
            // 
            // txtFuzzyPattern
            // 
            this.txtFuzzyPattern.Location = new System.Drawing.Point(10, 165);
            this.txtFuzzyPattern.Name = "txtFuzzyPattern";
            this.txtFuzzyPattern.Size = new System.Drawing.Size(150, 20);
            this.txtFuzzyPattern.TabIndex = 6;
            // 
            // lblFuzzyPattern
            // 
            this.lblFuzzyPattern.AutoSize = true;
            this.lblFuzzyPattern.Location = new System.Drawing.Point(10, 145);
            this.lblFuzzyPattern.Name = "lblFuzzyPattern";
            this.lblFuzzyPattern.Size = new System.Drawing.Size(91, 13);
            this.lblFuzzyPattern.TabIndex = 5;
            this.lblFuzzyPattern.Text = "Нечёткий поиск:";
            // 
            // btnSearchVariant
            // 
            this.btnSearchVariant.Location = new System.Drawing.Point(10, 105);
            this.btnSearchVariant.Name = "btnSearchVariant";
            this.btnSearchVariant.Size = new System.Drawing.Size(260, 30);
            this.btnSearchVariant.TabIndex = 4;
            this.btnSearchVariant.Text = "Поиск по длине и исключаемым буквам";
            this.btnSearchVariant.UseVisualStyleBackColor = true;
            this.btnSearchVariant.Click += new System.EventHandler(this.btnSearchVariant_Click);
            // 
            // txtExcludeLetters
            // 
            this.txtExcludeLetters.Location = new System.Drawing.Point(10, 75);
            this.txtExcludeLetters.Name = "txtExcludeLetters";
            this.txtExcludeLetters.Size = new System.Drawing.Size(260, 20);
            this.txtExcludeLetters.TabIndex = 3;
            // 
            // lblExcludeLetters
            // 
            this.lblExcludeLetters.AutoSize = true;
            this.lblExcludeLetters.Location = new System.Drawing.Point(10, 55);
            this.lblExcludeLetters.Name = "lblExcludeLetters";
            this.lblExcludeLetters.Size = new System.Drawing.Size(117, 13);
            this.lblExcludeLetters.TabIndex = 2;
            this.lblExcludeLetters.Text = "Исключаемые буквы:";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(120, 22);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(150, 20);
            this.txtLength.TabIndex = 1;
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(10, 25);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(108, 13);
            this.lblLength.TabIndex = 0;
            this.lblLength.Text = "Длина слова (букв):";
            // 
            // groupBoxResults
            // 
            this.groupBoxResults.Controls.Add(this.btnClearResults);
            this.groupBoxResults.Controls.Add(this.btnSaveResults);
            this.groupBoxResults.Controls.Add(this.txtSearchResults);
            this.groupBoxResults.Location = new System.Drawing.Point(592, 12);
            this.groupBoxResults.Name = "groupBoxResults";
            this.groupBoxResults.Size = new System.Drawing.Size(280, 500);
            this.groupBoxResults.TabIndex = 4;
            this.groupBoxResults.TabStop = false;
            this.groupBoxResults.Text = "Результаты поиска";
            // 
            // btnClearResults
            // 
            this.btnClearResults.Location = new System.Drawing.Point(145, 461);
            this.btnClearResults.Name = "btnClearResults";
            this.btnClearResults.Size = new System.Drawing.Size(125, 34);
            this.btnClearResults.TabIndex = 2;
            this.btnClearResults.Text = "Очистить";
            this.btnClearResults.UseVisualStyleBackColor = true;
            this.btnClearResults.Click += new System.EventHandler(this.btnClearResults_Click);
            // 
            // btnSaveResults
            // 
            this.btnSaveResults.Location = new System.Drawing.Point(10, 461);
            this.btnSaveResults.Name = "btnSaveResults";
            this.btnSaveResults.Size = new System.Drawing.Size(125, 34);
            this.btnSaveResults.TabIndex = 1;
            this.btnSaveResults.Text = "Сохранить результаты";
            this.btnSaveResults.UseVisualStyleBackColor = true;
            this.btnSaveResults.Click += new System.EventHandler(this.btnSaveResults_Click);
            // 
            // txtSearchResults
            // 
            this.txtSearchResults.Location = new System.Drawing.Point(10, 25);
            this.txtSearchResults.Multiline = true;
            this.txtSearchResults.Name = "txtSearchResults";
            this.txtSearchResults.ReadOnly = true;
            this.txtSearchResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSearchResults.Size = new System.Drawing.Size(260, 430);
            this.txtSearchResults.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 550);
            this.Controls.Add(this.groupBoxResults);
            this.Controls.Add(this.groupBoxSearch);
            this.Controls.Add(this.groupBoxView);
            this.Controls.Add(this.groupBoxDictionary);
            this.Controls.Add(this.statusStrip);
            this.Name = "Form1";
            this.Text = "Работа со словарём";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBoxDictionary.ResumeLayout(false);
            this.groupBoxDictionary.PerformLayout();
            this.groupBoxView.ResumeLayout(false);
            this.groupBoxView.PerformLayout();
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.groupBoxResults.ResumeLayout(false);
            this.groupBoxResults.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}