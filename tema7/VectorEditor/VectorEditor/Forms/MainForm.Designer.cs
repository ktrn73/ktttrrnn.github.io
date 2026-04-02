namespace VectorEditor.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.canvas = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.undoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.copyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figuresMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pentagonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexagonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.star5MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.star6MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnCut = new System.Windows.Forms.ToolStripButton();
            this.btnPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnColor = new System.Windows.Forms.ToolStripButton();
            this.lblStrokeWidth = new System.Windows.Forms.ToolStripLabel();
            this.nudStrokeWidth = new System.Windows.Forms.NumericUpDown();
            this.toolStripControlHost = new System.Windows.Forms.ToolStripControlHost(this.nudStrokeWidth);
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTriangle = new System.Windows.Forms.ToolStripButton();
            this.btnSquare = new System.Windows.Forms.ToolStripButton();
            this.btnPentagon = new System.Windows.Forms.ToolStripButton();
            this.btnHexagon = new System.Windows.Forms.ToolStripButton();
            this.btnStar5 = new System.Windows.Forms.ToolStripButton();
            this.btnStar6 = new System.Windows.Forms.ToolStripButton();

            this.SuspendLayout();

            // canvas
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 49);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1024, 668);
            this.canvas.TabIndex = 0;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            this.canvas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Canvas_KeyDown);

            // menuStrip
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.fileMenu,
                this.editMenu,
                this.figuresMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1024, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";

            // fileMenu
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.newMenuItem,
                this.openMenuItem,
                this.saveMenuItem,
                this.toolStripSeparator1,
                this.exitMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(48, 20);
            this.fileMenu.Text = "Файл";

            this.newMenuItem.Name = "newMenuItem";
            this.newMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newMenuItem.Size = new System.Drawing.Size(186, 22);
            this.newMenuItem.Text = "Новый";
            this.newMenuItem.Click += new System.EventHandler(this.NewFile_Click);

            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openMenuItem.Text = "Открыть...";
            this.openMenuItem.Click += new System.EventHandler(this.OpenFile_Click);

            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveMenuItem.Text = "Сохранить...";
            this.saveMenuItem.Click += new System.EventHandler(this.SaveFile_Click);

            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);

            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(186, 22);
            this.exitMenuItem.Text = "Выход";
            this.exitMenuItem.Click += (s, e) => this.Close();

            // editMenu
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.undoMenuItem,
                this.toolStripSeparator2,
                this.copyMenuItem,
                this.cutMenuItem,
                this.pasteMenuItem,
                this.toolStripSeparator3,
                this.deleteMenuItem});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(59, 20);
            this.editMenu.Text = "Правка";

            this.undoMenuItem.Name = "undoMenuItem";
            this.undoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoMenuItem.Size = new System.Drawing.Size(174, 22);
            this.undoMenuItem.Text = "Отменить";
            this.undoMenuItem.Click += new System.EventHandler(this.Undo_Click);

            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);

            this.copyMenuItem.Name = "copyMenuItem";
            this.copyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyMenuItem.Size = new System.Drawing.Size(174, 22);
            this.copyMenuItem.Text = "Копировать";
            this.copyMenuItem.Click += new System.EventHandler(this.Copy_Click);

            this.cutMenuItem.Name = "cutMenuItem";
            this.cutMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutMenuItem.Size = new System.Drawing.Size(174, 22);
            this.cutMenuItem.Text = "Вырезать";
            this.cutMenuItem.Click += new System.EventHandler(this.Cut_Click);

            this.pasteMenuItem.Name = "pasteMenuItem";
            this.pasteMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteMenuItem.Size = new System.Drawing.Size(174, 22);
            this.pasteMenuItem.Text = "Вставить";
            this.pasteMenuItem.Click += new System.EventHandler(this.Paste_Click);

            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(171, 6);

            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteMenuItem.Size = new System.Drawing.Size(174, 22);
            this.deleteMenuItem.Text = "Удалить";
            this.deleteMenuItem.Click += new System.EventHandler(this.Delete_Click);

            // figuresMenu
            this.figuresMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.triangleMenuItem,
                this.squareMenuItem,
                this.pentagonMenuItem,
                this.hexagonMenuItem,
                this.toolStripSeparator4,
                this.star5MenuItem,
                this.star6MenuItem});
            this.figuresMenu.Name = "figuresMenu";
            this.figuresMenu.Size = new System.Drawing.Size(66, 20);
            this.figuresMenu.Text = "Фигуры";

            this.triangleMenuItem.Name = "triangleMenuItem";
            this.triangleMenuItem.Size = new System.Drawing.Size(180, 22);
            this.triangleMenuItem.Text = "Треугольник (3)";
            this.triangleMenuItem.Click += (s, e) => AddPolygon(3);

            this.squareMenuItem.Name = "squareMenuItem";
            this.squareMenuItem.Size = new System.Drawing.Size(180, 22);
            this.squareMenuItem.Text = "Квадрат (4)";
            this.squareMenuItem.Click += (s, e) => AddPolygon(4);

            this.pentagonMenuItem.Name = "pentagonMenuItem";
            this.pentagonMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pentagonMenuItem.Text = "Пятиугольник (5)";
            this.pentagonMenuItem.Click += (s, e) => AddPolygon(5);

            this.hexagonMenuItem.Name = "hexagonMenuItem";
            this.hexagonMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hexagonMenuItem.Text = "Шестиугольник (6)";
            this.hexagonMenuItem.Click += (s, e) => AddPolygon(6);

            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);

            this.star5MenuItem.Name = "star5MenuItem";
            this.star5MenuItem.Size = new System.Drawing.Size(180, 22);
            this.star5MenuItem.Text = "Звезда 5-конечная";
            this.star5MenuItem.Click += (s, e) => AddStar(5);

            this.star6MenuItem.Name = "star6MenuItem";
            this.star6MenuItem.Size = new System.Drawing.Size(180, 22);
            this.star6MenuItem.Text = "Звезда 6-конечная";
            this.star6MenuItem.Click += (s, e) => AddStar(6);

            // toolStrip
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.btnNew,
                this.btnOpen,
                this.btnSave,
                this.toolStripSeparator5,
                this.btnUndo,
                this.toolStripSeparator6,
                this.btnCopy,
                this.btnCut,
                this.btnPaste,
                this.toolStripSeparator7,
                this.btnDelete,
                this.toolStripSeparator8,
                this.btnColor,
                this.lblStrokeWidth,
                this.toolStripControlHost,
                this.toolStripSeparator9,
                this.btnTriangle,
                this.btnSquare,
                this.btnPentagon,
                this.btnHexagon,
                this.btnStar5,
                this.btnStar6});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1024, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip";

            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNew.Text = "Новый";
            this.btnNew.ToolTipText = "Создать новый рисунок";
            this.btnNew.Click += new System.EventHandler(this.NewFile_Click);

            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOpen.Text = "Открыть";
            this.btnOpen.ToolTipText = "Открыть файл";
            this.btnOpen.Click += new System.EventHandler(this.OpenFile_Click);

            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Text = "Сохранить";
            this.btnSave.ToolTipText = "Сохранить рисунок";
            this.btnSave.Click += new System.EventHandler(this.SaveFile_Click);

            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);

            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUndo.Text = "Отменить";
            this.btnUndo.ToolTipText = "Отменить последнее действие";
            this.btnUndo.Click += new System.EventHandler(this.Undo_Click);

            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);

            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCopy.Text = "Копировать";
            this.btnCopy.ToolTipText = "Копировать выделенную фигуру";
            this.btnCopy.Click += new System.EventHandler(this.Copy_Click);

            this.btnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCut.Text = "Вырезать";
            this.btnCut.ToolTipText = "Вырезать выделенную фигуру";
            this.btnCut.Click += new System.EventHandler(this.Cut_Click);

            this.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPaste.Text = "Вставить";
            this.btnPaste.ToolTipText = "Вставить фигуру из буфера обмена";
            this.btnPaste.Click += new System.EventHandler(this.Paste_Click);

            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);

            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.ToolTipText = "Удалить выделенную фигуру";
            this.btnDelete.Click += new System.EventHandler(this.Delete_Click);

            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);

            this.btnColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnColor.Text = "Цвет контура";
            this.btnColor.ToolTipText = "Изменить цвет контура выделенной фигуры";
            this.btnColor.Click += new System.EventHandler(this.BtnColor_Click);

            this.lblStrokeWidth.Name = "lblStrokeWidth";
            this.lblStrokeWidth.Size = new System.Drawing.Size(91, 22);
            this.lblStrokeWidth.Text = "Толщина контура:";

            this.nudStrokeWidth.Minimum = 1;
            this.nudStrokeWidth.Maximum = 10;
            this.nudStrokeWidth.Value = 2;
            this.nudStrokeWidth.Width = 50;
            this.nudStrokeWidth.ValueChanged += new System.EventHandler(this.NudStrokeWidth_ValueChanged);

            this.toolStripControlHost.Name = "toolStripControlHost";
            this.toolStripControlHost.Size = new System.Drawing.Size(50, 25);

            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);

            this.btnTriangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTriangle.Text = "Треугольник";
            this.btnTriangle.ToolTipText = "Добавить треугольник";
            this.btnTriangle.Click += (s, e) => AddPolygon(3);

            this.btnSquare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSquare.Text = "Квадрат";
            this.btnSquare.ToolTipText = "Добавить квадрат";
            this.btnSquare.Click += (s, e) => AddPolygon(4);

            this.btnPentagon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPentagon.Text = "Пятиугольник";
            this.btnPentagon.ToolTipText = "Добавить пятиугольник";
            this.btnPentagon.Click += (s, e) => AddPolygon(5);

            this.btnHexagon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnHexagon.Text = "Шестиугольник";
            this.btnHexagon.ToolTipText = "Добавить шестиугольник";
            this.btnHexagon.Click += (s, e) => AddPolygon(6);

            this.btnStar5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnStar5.Text = "Звезда 5";
            this.btnStar5.ToolTipText = "Добавить пятиконечную звезду";
            this.btnStar5.Click += (s, e) => AddStar(5);

            this.btnStar6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnStar6.Text = "Звезда 6";
            this.btnStar6.ToolTipText = "Добавить шестиконечную звезду";
            this.btnStar6.Click += (s, e) => AddStar(6);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 717);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Векторный редактор - Вариант 7";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem newMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem undoMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem copyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figuresMenu;
        private System.Windows.Forms.ToolStripMenuItem triangleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squareMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pentagonMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexagonMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem star5MenuItem;
        private System.Windows.Forms.ToolStripMenuItem star6MenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripButton btnCut;
        private System.Windows.Forms.ToolStripButton btnPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnColor;
        private System.Windows.Forms.ToolStripLabel lblStrokeWidth;
        private System.Windows.Forms.NumericUpDown nudStrokeWidth;
        private System.Windows.Forms.ToolStripControlHost toolStripControlHost;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton btnTriangle;
        private System.Windows.Forms.ToolStripButton btnSquare;
        private System.Windows.Forms.ToolStripButton btnPentagon;
        private System.Windows.Forms.ToolStripButton btnHexagon;
        private System.Windows.Forms.ToolStripButton btnStar5;
        private System.Windows.Forms.ToolStripButton btnStar6;
    }
}